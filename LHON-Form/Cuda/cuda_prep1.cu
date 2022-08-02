﻿#define rate_tissue_index_xy 10
#define rate_tissue_index_z 11

extern "C" __global__  void cuda_prep1(unsigned short im_size, unsigned char* pix_out_of_nerve, unsigned char* rate, int rate_dimensions)
{
	int x = blockIdx.x * blockDim.x + threadIdx.x;
	int y = blockIdx.y * blockDim.y + threadIdx.y;

	if (x < im_size && y < im_size)
	{
		int xy = x * im_size + y;
		int xyN = xy * rate_dimensions;

		if (pix_out_of_nerve[xy]) {
			rate[xyN] = rate_tissue_index_xy;
			rate[xyN + 1] = rate_tissue_index_xy;
			rate[xyN + 2] = rate_tissue_index_xy;
			rate[xyN + 3] = rate_tissue_index_xy;
			if (rate_dimensions > 4) {
				rate[xyN + 4] = rate_tissue_index_z;
				rate[xyN + 5] = rate_tissue_index_z;
			}
		}
		else {
			if (pix_out_of_nerve[xy + im_size]) rate[xyN] = rate_tissue_index_xy;
			if (pix_out_of_nerve[xy - im_size]) rate[xyN + 1] = rate_tissue_index_xy;
			if (pix_out_of_nerve[xy + 1])		rate[xyN + 2] = rate_tissue_index_xy;
			if (pix_out_of_nerve[xy - 1])		rate[xyN + 3] = rate_tissue_index_xy;
		}
	}
}

// Set nerve boundary rates to 0
//for (int y = 0; y < im_size; y++)
//    for (int x = 0; x < im_size; x++)
//    {
//        int[,] neighbors = new int[,] { { x + 1, y }, { x - 1, y }, { x, y + 1 }, { x, y - 1 } };
//        for (uint k = 0; k < 4; k++)
//            if (pix_out_of_nerve[x, y] || pix_out_of_nerve[neighbors[k, 0], neighbors[k, 1]])
//                rate[x, y, k] = 0;
//    }
