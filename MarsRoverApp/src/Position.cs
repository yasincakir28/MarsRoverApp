using System;
using System.Collections.Generic;

namespace MarsRoverApp
{    
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        private void Rotate90Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void Rotate90Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// İlgili method girdi olarak iletilen kordinatlar doğrultusunda rover'ın hareket etmesini sağlar.
        /// </summary>
        /// <param name="maxSize">Rover'ın ne kadarlık bir alanda hareket edeceği bilgisini verir. </param>
        /// <param name="directions"> Rover'ın takip edeceği yön bilgisini verir. </param>
        public void Start(List<int> maxSize, string directions)
        {
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case 'M':
                        this.MoveInSameDirection();
                        break;
                    case 'L':
                        this.Rotate90Left();
                        break;
                    case 'R':
                        this.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Geçersiz Karakter {direction}");
                        break;
                }

                if (this.X < 0 || this.X > maxSize[0] || this.Y < 0 || this.Y > maxSize[1])
                {
                    throw new Exception($"Pozisyon sınırların ötesinde olamaz (0 , 0) ve ({maxSize[0]} , {maxSize[1]})");
                }
            }
        }
    }
}
