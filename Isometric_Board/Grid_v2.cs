﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricRenderEngine
{
    class Grid_v2
    {
        int x_offset = 376;
        int y_offset = 220;

        public int gridSize = 7; // the width and length of the isometric grid (check the gridmap array)
        public int gridSizeZ = 7; // the height of the isometric grid (number of layer string arrays)

<<<<<<< HEAD
        public int assestsSize;

        int x_tile_offset;
        int y_tile_offset;
        int z_tile_offset;

=======
>>>>>>> parent of 1e710e4... Now 64x64 based compared to the previous 48x48 (nicer to work with more complex shapes) got a basic player going and the bottom tiles are now slabs
        public List<Point[,]> Layers = new List<Point[,]>();

        //public Point[,] Layer;

        public Grid_v2(int desiredAssestsSize)
        {
            assestsSize = desiredAssestsSize;

            switch (assestsSize) // sets appropriate grid offsets depending on the dimensions of the isometric sprites used
            {
                case 16:
                    x_tile_offset = 16;
                    y_tile_offset = 8;
                    z_tile_offset = 16;
                    break;

                case 48:
                    x_tile_offset = 22;
                    y_tile_offset = 11;
                    z_tile_offset = 23;
                    break;

                default:
                case 64:
                    x_tile_offset = 32;
                    y_tile_offset = 16;
                    z_tile_offset = 32;
                    break;
            }

            for (int i = 0; i < gridSizeZ; i++)
            {
                Layers.Add(loadLayer(i));
            }
        }

        public Point[,] loadLayer(int layerNumber)
        {
            Point[,] Layer = new Point[gridSize, gridSize];

            int layer_y;

            layer_y = y_offset - (23 * layerNumber);

            for (int i = 0; i < gridSize; i++)
            {
                Layer[i, 0] = new Point(x_offset + (22 * (i+1)), layer_y + (11 * (i + 1)));
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Point previousTile;//= new Point(0,0);

                    if (i == 0)
                    {
                        previousTile = Layer[x, i];
                    }
                    else
                    {
                        previousTile = Layer[x, i - 1];
                    }

                    Layer[x,i] = new Point(previousTile.X - 22, previousTile.Y + 11);
                }
            }

            return Layer;
        }
    }
}
