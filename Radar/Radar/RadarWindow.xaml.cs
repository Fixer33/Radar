using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Radar
{
    /// <summary>
    /// Interaction logic for RadarWindow.xaml
    /// </summary>
    public partial class RadarWindow : Window
    {
        public RadarWindow(List<Sensor> sensorList, Window1 authForm, DataEnterWindow dew)
        {
            InitializeComponent();
            this.sensorList = sensorList;
            this.authForm = authForm;
            this.dew = dew;
        }

        private Window1 authForm;
        private DataEnterWindow dew;
        private SensorDataWindow sdw;
        private FuncButtonsWIndow fbw;

        private List<(Ellipse circle, Label text)> sensorMarkers = new List<(Ellipse circle, Label text)>();
        private List<(Line line, int sensor1, int sensor2)> sensorLines = new List<(Line line, int sensor1, int sensor2)>();

        private const float FirstCircleDiameterPerc = 14.28571f;
        private const double sensorCircleRadius = 20d;
        private const double targetCircleRadius = 30d;
        private const float TargetSpeed = 10f;

        private List<Sensor> sensorList;

        //private SolidColorBrush centerFill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 98, 0));
        private SolidColorBrush centerFill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
        private SolidColorBrush centerStroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
        private SolidColorBrush radarCirclesStroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 98, 0));
        private SolidColorBrush sensorFill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 151, 0));
        private SolidColorBrush sensorStroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 151, 0));

        private SolidColorBrush targetFill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(163, 0, 0));
        private SolidColorBrush targetStroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(163, 0, 0));

        private float MinSide;
        private float MaxSide;

        private float centerRadiusPerc = 5f;

        private System.Windows.Forms.Timer timer;

        private List<Ellipse> targets = new List<Ellipse>();

        private List<float> targetDistances = new List<float>();
        private List<(int one, int two)> targetSensors = new List<(int one, int two)>();

        private List<Ellipse> radarCircles = new List<Ellipse>();

        public void LaunchTest()
        {
            if (isAlarmOn)
            {
                MessageBox.Show("Нельзя начать тестирование во время тревоги");
                return;
            }

            Random r = new Random();
            PointF posToSpawn = Calc.GetPointFByAngleAndDist(r.Next(0, 360), MinSide, new PointF(0, 0));

            List<PointF> temp = new List<PointF>();
            foreach (Sensor sensor in sensorList)
            {
                PointF pos = Calc.GetPointFByAngleAndDist(sensor.Angle, sensor.Distance, new PointF(0, 0));
                temp.Add(new PointF(pos.Y, pos.X));
            }

            if (Calc.CheckCollision(posToSpawn, new PointF(0, 0), temp.ToArray(), out float distance, out int one, out int two))
            {
                Ellipse newTarget = PlaceCircle(targetFill, targetStroke, 1, targetCircleRadius, targetCircleRadius, posToSpawn);
                targets.Add(newTarget);
                targetDistances.Add(distance);
                targetSensors.Add((one, two));
            }
            
        }

        private SolidColorBrush RadarDefaultColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 36, 0));
        private SolidColorBrush RadarPanicColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(36, 0, 0));
        private SolidColorBrush radarCirclesStroke_Panic = new SolidColorBrush(System.Windows.Media.Color.FromRgb(98, 0, 0));

        private System.Media.SoundPlayer sp;

        private bool isAlarmOn = false;

        public void ActivatePanic()
        {
            System.IO.Stream str = Properties.Resources.Alarm_sound;
            sp = new System.Media.SoundPlayer(str);
            sp.Play();

            foreach (Line line in radarLines)
            {
                line.Stroke = radarCirclesStroke_Panic;
            }
            foreach (Ellipse ellipse in radarCircles)
            {
                ellipse.Stroke = radarCirclesStroke_Panic;
            }
            MainGrid.Background = RadarPanicColor;
            isAlarmOn = true;
        }

        private void DefensiveAreaEnter()
        {
            timer.Enabled = false;
            PanicWindow pw = new PanicWindow("");
            pw.rw = this;
            pw.ShowDialog();
        }
        private void DefensiveAreaEnter(int i, PointF targetPos)
        {
            timer.Enabled = false;
            PanicWindow pw = new PanicWindow(Calc.GetDirection(targetPos, new PointF(0,0)) + $" (Датчики {targetSensors[i].one + 1} и {targetSensors[i].two + 1})");
            pw.rw = this;
            pw.ShowDialog();
        }

        public void ReturnToStation()
        {
            if (sp != null) sp.Stop();
            timer.Enabled = true;
            foreach (Line line in radarLines)
            {
                line.Stroke = radarCirclesStroke;
            }
            foreach (Ellipse ellipse in radarCircles)
            {
                ellipse.Stroke = radarCirclesStroke;
            }
            MainGrid.Background = RadarDefaultColor;
            isAlarmOn = false;
        }

        private void MoveTargets()
        {
            for (int i = 0; i < targets.Count; i++)
            {
                
                PointF targetPos = new PointF((float)targets[i].Margin.Left, (float)targets[i].Margin.Bottom);
                PointF newPos = Calc.StepOfPointTowardCentr(targetPos, new PointF(0, 0), TargetSpeed);
                targets[i].Margin = new Thickness(newPos.X, 0, 0, newPos.Y);

                var distance = Calc.GetDistanceBetweenPoints(targetPos, new PointF(0, 0));
                if (distance <= targetDistances[i])
                {
                    DefensiveAreaEnter(i, targetPos);
                    MainGrid.Children.Remove(targets[i]);
                    targetDistances.RemoveAt(i);
                    targets.RemoveAt(i);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //icon
            this.Icon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.RadarIcon.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            if (Width-6 >= Height-29)
            {
                MinSide = (float)Height-29;
                MaxSide = (float)Width-6;
            }
            else
            {
                MinSide = (float)Width-6;
                MaxSide = (float)Height-29;
            }

            //Center circle
            PlaceCircle(centerFill, centerStroke, 2, MinSide * (centerRadiusPerc / 100), MinSide * (centerRadiusPerc / 100));

            int circleCount = (int)(MaxSide / (MinSide * FirstCircleDiameterPerc / 100));
            for (int i = 0; i < circleCount; i++)
            {
                radarCircles.Add(PlaceCircle(new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 255, 255, 255)), radarCirclesStroke, 4, (MinSide * FirstCircleDiameterPerc / 100) * (i + 1), (MinSide * FirstCircleDiameterPerc / 100) * (i + 1)));
            }
            DrawradarLines();

            OpenSensorPanel();
            DrawSensors();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, evargs) =>
            {
                MoveTargets();
            };
            timer.Start();
        }

        private List<Line> radarLines = new List<Line>();

        private void DrawradarLines()
        {
            float HalfWidth = (float)Width / 2;
            float HalfHeight = (float)Height / 2;

            radarLines.Add(PlaceLine(new PointF(HalfWidth-7, 0), new PointF(HalfWidth-7, (float)Height), radarCirclesStroke, 1));
            radarLines.Add(PlaceLine(new PointF(0, HalfHeight - 19), new PointF((float)Width, HalfHeight - 19), radarCirclesStroke, 1));
        }

        private Line PlaceLine(PointF point1, PointF point2, SolidColorBrush stroke, int thickness)
        {
            Line line = new Line();
            MainGrid.Children.Add(line);
            line.Stroke = stroke;
            line.StrokeThickness = thickness;
            line.X1 = point1.X;
            line.X2 = point2.X;
            line.Y1 = point1.Y;
            line.Y2 = point2.Y;
            return line;
        }

        private void DrawSensors()
        {
            foreach (Sensor sensor in sensorList)
            {
                PointF sensorPos = Calc.GetPointFByAngleAndDist(sensor.Angle, sensor.Distance, new PointF(0, 0));
                Ellipse sensorCircle = PlaceCircle(sensorFill, sensorStroke, 1, sensorCircleRadius, sensorCircleRadius, /*sensorPos*/new PointF(sensorPos.Y, sensorPos.X));
                Label sensorText = PlaceLabel(sensorStroke, sensorCircle, "D" + (sensor.Number + 1).ToString());
                sensorMarkers.Add((sensorCircle, sensorText));
            }
            for (int i = 0; i < sensorMarkers.Count - 1; i++)
            {
                Line line = PlaceLine(sensorMarkers[i].circle, sensorMarkers[i + 1].circle, sensorStroke, 1);
                sensorLines.Add((line, sensorList[i].Number, sensorList[i + 1].Number));
            }
            if (sensorMarkers.Count < 2) return;
            Line nLine = PlaceLine(sensorMarkers[sensorMarkers.Count - 1].circle, sensorMarkers[0].circle, sensorStroke, 1);
            sensorLines.Add((nLine, sensorMarkers.Count - 1, 0));
        }

        private Line PlaceLine(Shape from, Shape to, SolidColorBrush color, int thickness)
        {
            Line newLine = new Line();
            MainGrid.Children.Add(newLine);
            /*newLine.VerticalAlignment = VerticalAlignment.Center;
            newLine.HorizontalAlignment = HorizontalAlignment.Center;*/
            float CenterX = (float)((Width - 6) / 2);
            float CenterY = (float)((Height - 29) / 2);
            var from_point = new PointF((float)(CenterX + from.Margin.Left/2), (float)(CenterY - from.Margin.Bottom/2));
            newLine.X1 = from_point.X;
            newLine.Y1 = from_point.Y;
            var to_point = new PointF((float)(CenterX + to.Margin.Left/2), (float)(CenterY - to.Margin.Bottom/2));
            newLine.X2 = to_point.X;
            newLine.Y2 = to_point.Y;
            newLine.Stroke = color;
            newLine.StrokeThickness = thickness;
            return newLine;
        }

        private Label PlaceLabel(SolidColorBrush color, Shape object_to_place_above, string text)
        {
            const double Offset = 20;
            Label label = new Label();
            MainGrid.Children.Add(label);
            label.Content = text;
            label.Foreground = color;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            Thickness pos = object_to_place_above.Margin;
            label.Margin = new Thickness(pos.Left, pos.Top + Offset, pos.Right, pos.Bottom - Offset);
            return label;
        }

        private void OpenSensorPanel()
        {
            SensorDataWindow sdw = new SensorDataWindow();
            FuncButtonsWIndow fbw = new FuncButtonsWIndow();
            sdw.SetSensors(sensorList);
            fbw.rdrw = this;

            var location = this.PointToScreen(new System.Windows.Point(0, 0));
            sdw.Top = location.Y - 29;
            sdw.Left = location.X + Width;
            var location_fbw = new System.Windows.Point(location.X + Width, location.Y - 29);
            fbw.Top = location_fbw.Y + sdw.Height;
            fbw.Left = location_fbw.X;

            this.sdw = sdw;
            this.fbw = fbw;
            sdw.Show();
            fbw.Show();
        }

        private Ellipse PlaceCircle(SolidColorBrush fill, SolidColorBrush stroke, int thickness, double width, double heigth)
        {
            return PlaceCircle(fill, stroke, thickness, width, heigth, new PointF(0, 0));
        }
        private Ellipse PlaceCircle(SolidColorBrush fill, SolidColorBrush stroke, int thickness, double width, double heigth, PointF from_center)
        {
            Ellipse newCircle = new Ellipse();
            MainGrid.Children.Add(newCircle);
            newCircle.Fill = fill;
            newCircle.Stroke = stroke;
            newCircle.StrokeThickness = thickness;
            newCircle.Width = width - thickness * 2;
            newCircle.Height = heigth - thickness * 2;

            newCircle.VerticalAlignment = VerticalAlignment.Center;
            newCircle.HorizontalAlignment = HorizontalAlignment.Center;

            Thickness pos = new Thickness(from_center.X, 0, 0, from_center.Y);
            newCircle.Margin = pos;

            return newCircle;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            authForm.Close();
            sdw.Close();
            fbw.Close();
            dew.Close();
        }


        private void Window_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                var location = this.PointToScreen(new System.Windows.Point(0, 0));
                sdw.Top = location.Y - 29;
                sdw.Left = location.X + Width;
                var location_fbw = new System.Windows.Point(location.X + Width, location.Y - 29);
                fbw.Top = location_fbw.Y + sdw.Height;
                fbw.Left = location_fbw.X;
            }
            catch
            {

            }
        }
        
    }
}
