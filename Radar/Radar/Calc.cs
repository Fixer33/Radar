using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    class Calc
    {
        /// <summary>
        /// Angle relative  x-axis
        /// </summary>
        /// <param name="coord">point</param>
        /// <returns></returns>
        public float GetAngle(PointF coord)
        {
            float angle = (float)(Math.Atan2(coord.Y, coord.X) * 57.2957795130823);// 57... = 180/PI ;
            angle = (angle < 0) ? angle + 360 : angle;
            return angle;

        }
        /// <summary>
        /// Angle relative  x-axis
        /// </summary>
        /// <param name="coord">point</param>
        /// <param name="origin">origin of coordinates</param>
        /// <returns></returns>
        public float GetAngle(PointF coord,PointF origin)
        {
            float angle = (float)(Math.Atan2(coord.Y-origin.Y, coord.X-origin.X) * 57.2957795130823);// 57... = 180/PI ;
            angle = (angle < 0) ? angle + 360 : angle;
            return angle;

        }


        /// <summary>
        /// Direction of "Attack" (relative (0,0))
        /// </summary>
        /// <param name="coord">point</param>
        /// <returns></returns>
        public string GetDirection(PointF coord)
        {
            float angle = GetAngle(coord);
            float min = 400f;
            int buf = 0;

            //Find direction
            for (int i = 0; i < 8; i++)  
            {
                float diff = Math.Abs(i * 45 - angle);
                if (diff < min)
                {
                    min = diff;
                    buf = i;
                }
            }

            switch (buf)
            {
                case 0 :
                    return "Восток";
                case 1:
                    return "Северо-Восток";
                case 2:
                    return "Север";
                case 3:
                    return "Северо-Запад";
                case 4:
                    return "Запад";
                case 5:
                    return "Юго-Запад";
                case 6:
                    return "Юг";
                case 7:
                    return "Юго-Восток";
                default:
                    return "Восток";
            }
        }

        /// <summary>
        /// Direction of "Attack" (relative origin of coordinates)
        /// </summary>
        /// <param name="coord">point</param>
        /// <param name="origin">origin of coordinates</param>
        /// <returns></returns>
        public string GetDirection(PointF coord,PointF origin)
        {
            float angle = GetAngle(coord,origin);
            float min = 400f;
            int buf = 0;

            //Find direction
            for (int i = 0; i < 8; i++)
            {
                float diff = Math.Abs(i * 45 - angle);
                if (diff < min)
                {
                    min = diff;
                    buf = i;
                }
            }

            switch (buf)
            {
                case 0:
                    return "Восток";
                case 1:
                    return "Северо-Восток";
                case 2:
                    return "Север";
                case 3:
                    return "Северо-Запад";
                case 4:
                    return "Запад";
                case 5:
                    return "Юго-Запад";
                case 6:
                    return "Юг";
                case 7:
                    return "Юго-Восток";
                default:
                    return "Восток";
            }
        }

      


        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="dist"> distance between points</param>
        /// <param name="source"> soure point</param>
        /// <returns></returns>
        public PointF GetPointFByAngleAndDist(float angle,float dist,PointF source)
        {
            angle =(float) (angle * Math.PI / 180);
            PointF result = new PointF((float)(source.X + dist * Math.Cos(angle)), (float)(source.Y + dist * Math.Sin(angle)));
            return result;
        }
            

        public float GetDistanceBetweenPoints (PointF point1,PointF point2)
        {
            float result =(float) Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point2.X,2));
            return result;
        }


       

        /// <summary>
        /// Проверяет, попадёт ли точка в контур по пути к центру
        /// </summary>
        /// <param name="point">Проверяемая точка</param>
        /// <param name="centr">Центр</param>
        /// <param name="sensors">Контур сенсоров</param>
        /// <param name="dist">Расстояние от центра до точки пересечения "проверяемой" точки с контуром</param>
        /// <returns>true - точка переекает контур на расстоянии dist от центра (если точка на расстоянии меньше чем dist от центра , то  она пересекла контур) , false - точка не пересекает контур по пути к центру.</returns>
        public bool CheckCollision (PointF point , PointF centr, PointF[] sensors, out float dist)
        {
            dist = 0;
            for (int i = 0; i < sensors.Length; i++)
            {
                int buf_state = -1;
                int buf_rslt =  0 ;
                PointF result = GetIntersectionPointOfTwoLines(point, centr, sensors[i], sensors[(i + 1) % sensors.Length], out buf_state);
                if (buf_state != 1 )
                    continue;
                else
                {
                    buf_rslt= GetDistanceBetweenPoints(centr, result);
                    if(dist<buf_rslt)
                    {
                        dist=buf_rslt;
                    } 
                }
            }
            if (dist > 0  )
                return true;
            else
                return false;


        }

        /// <summary>
        /// Возвращает точку пересечения двух прямых
        /// </summary>
        /// <param name="p1_1">Первая точка прямой 1</param>
        /// <param name="p1_2">Вторая точка прямой 1</param>
        /// <param name="p2_1">Первая точка прямой 2</param>
        /// <param name="p2_2">Вторая точка прямой 2</param>
        /// <param name="state">-1, если параллельны, 0 если совпадают, 1 если пересекаются</param>
        /// <returns></returns>
        public static PointF GetIntersectionPointOfTwoLines(PointF p1_1, PointF p1_2, PointF p2_1, PointF p2_2, out int state)
        {
            state = -2;
            PointF result = new PointF();
            //Если знаменатель (n) равен нулю, то прямые параллельны.
            //Если и числитель (m или w) и знаменатель (n) равны нулю, то прямые совпадают.
            //Если нужно найти пересечение отрезков, то нужно лишь проверить, лежат ли ua и ub на промежутке [0,1].
            //Если какая-нибудь из этих двух переменных 0 <= ui <= 1, то соответствующий отрезок содержит точку пересечения.
            //Если обе переменные приняли значения из [0,1], то точка пересечения прямых лежит внутри обоих отрезков.
            float m = ((p2_2.X - p2_1.X) * (p1_1.Y - p2_1.Y) - (p2_2.Y - p2_1.Y) * (p1_1.X - p2_1.X));
            float w = ((p1_2.X - p1_1.X) * (p1_1.Y - p2_1.Y) - (p1_2.Y - p1_1.Y) * (p1_1.X - p2_1.X)); 
            float n = ((p2_2.Y - p2_1.Y) * (p1_2.X - p1_1.X) - (p2_2.X - p2_1.X) * (p1_2.Y - p1_1.Y));

            float Ua = m / n;
            float Ub = w / n;

            if ((n == 0) && (m != 0))
            {
                state = -1; //Прямые параллельны (не имеют пересечения)
            }
            else if ((m == 0) && (n == 0))
            {
                state = 0; //Прямые совпадают
            }
            else
            {
                //Прямые имеют точку пересечения
                result.X = p1_1.X + Ua * (p1_2.X - p1_1.X);
                result.Y = p1_1.Y + Ua * (p1_2.Y - p1_1.Y);

                // Проверка попадания в интервал
                bool a = result.X >= p1_1.X; bool b = result.X <= p1_1.X; bool c = result.X >= p2_1.X; bool d = result.X <= p2_1.X;
                bool e = result.Y >= p1_1.Y; bool f = result.Y <= p1_1.Y; bool g = result.Y >= p2_1.Y; bool h = result.Y <= p2_1.Y;

                if (((a || b) && (c || d)) && ((e || f) && (g || h)))
                {
                    state = 1; //Прямые имеют точку пересечения
                }
            }
            return result;
        }

        public PointF StepOfPointTowardCentr(PointF point,PointF centr, float step )
        {
            float a = GetAngle(point, centr);
            return GetPointFByAngleAndDist(a, GetDistanceBetweenPoints(point, centr)- step, centr);

        }

        /// <summary>
        /// Check is Centr Inside the Area of sensors
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <param name="sensors">Points constituting area </param>
        /// <returns></returns>
        public bool CheckPointInsideArea(PointF point , PointF[] sensors)
        {
            PointF rand = GetPointFByAngleAndDist(31, 999, point);
            int count = 0;
            for (int i = 0; i < sensors.Length; i++)
            {
                int buf_state = -1;
                PointF result = GetIntersectionPointOfTwoLines(rand, point, sensors[i], sensors[(i + 1) % sensors.Length], out buf_state);
                if (buf_state != 1)
                    continue;
                else
                {
                    count++;
                }
            }
            if (count % 2 != 0)
                return true;
            else
                return false;

        }
    }
}
