
#define rate_extra_index 5
#define rate_extra_z_index 7

#define pixelInTissue 127
#define pixelOutsideOfTissue 255
#define noOpticZone  -1
#define  pi 3.141592654f

#define opticNerveZones 8
#define rate_tissue_index_xy 10
#define rate_tissue_index_z 11


/*
* [DWL] Need to keep the constants in this file in line with the values in preprocess.cs!!
		private readonly byte rate_zero_index = 0;
        private readonly byte rate_live_index = 1;
        private readonly byte rate_membrane_index = 2;
        private readonly byte rate_membrane_dead_index = 3;
        private readonly byte rate_dead_index = 4;
        private readonly byte rate_extra_index = 5;
        private readonly byte rate_live_z_index = 6;
        private readonly byte rate_extra_z_index = 7;
        private readonly byte rate_dead_z_index = 8;
        private readonly byte rate_membrane_stress_index = 9;
        private readonly byte rate_tissue_index_xy = 10;
        private readonly byte rate_tissue_index_z = 11;
        private readonly byte rate_one_index = 12;
        private readonly byte rate_values_size = 13;
*/

extern "C" __global__  void cuda_prep0(unsigned short im_size, int nerve_cent_pix, int nerve_r_pix_2, int vein_r_pix_2, float k_detox_extra,
	unsigned char* pix_out_of_nerve, unsigned char* rate, float* detox, unsigned int rate_dimensions, float* tox_prod, float outsideDetox, float* tox_dev, float initial_tox, unsigned char* simulation_point_mask, int* regionalMask, float* topoZoneAnglesRadian, float outsideToxProd, float noToxValue)
{
	int x = blockIdx.x * blockDim.x + threadIdx.x;
	int y = blockIdx.y * blockDim.y + threadIdx.y;

	if (x < im_size && y < im_size) {

		int xy = x * im_size + y;
		int xyN = xy * rate_dimensions;

		int dx = x - nerve_cent_pix;
		int dy = y - nerve_cent_pix;
		int dis2 = dx * dx + dy * dy;

		bool outside = nerve_r_pix_2 - dis2 < 0 || vein_r_pix_2 - dis2 > 0;
		pix_out_of_nerve[xy] = outside ? 1 : 0;
		
		if (!outside)
		{
			rate[xyN] = rate_extra_index;
			rate[xyN + 1] = rate_extra_index;
			rate[xyN + 2] = rate_extra_index;
			rate[xyN + 3] = rate_extra_index;
			if (rate_dimensions > 4) {
				rate[xyN + 4] = rate_extra_z_index;
				rate[xyN + 5] = rate_extra_z_index;
			}
			

			detox[xy] = k_detox_extra;
			tox_prod[xy] = noToxValue;			
			tox_dev[xy] = initial_tox;
			simulation_point_mask[xy] = pixelInTissue;
 
			if (pix_out_of_nerve[xy + im_size]) { rate[xyN] = rate_tissue_index_xy; pix_out_of_nerve[xy + im_size] = 2; }
			if (pix_out_of_nerve[xy - im_size]) { rate[xyN + 1] = rate_tissue_index_xy; pix_out_of_nerve[xy - im_size] = 2; }
			if (pix_out_of_nerve[xy + 1]) { rate[xyN + 2] = rate_tissue_index_xy; pix_out_of_nerve[xy + 1] = 2; }
			if (pix_out_of_nerve[xy - 1]) { rate[xyN + 3] = rate_tissue_index_xy; pix_out_of_nerve[xy - 1] = 2; }
			float theta = 0;
            if(dx == 0)
            {
               if (dy >= 0)
                   theta = pi / 2;
               else
                   theta = pi * 3 / 4;

            }else
            {

               if(dx < 0)
               {
                   if (dy >= 0)
                      theta = atanf((float)(-1.0)*dy / dx);
                   else
                      theta = 2*pi - atanf((float)dy / dx);
                   }
                   else
                   {
                     if (dy >= 0)
                        theta = pi - atanf((float) dy / dx);
                     else
                        theta = pi + atanf((float)(-1.0)* dy/ dx);
                   }
           }

               

           for (int q = 0; q < opticNerveZones+1; q++)
           {
              if (theta < topoZoneAnglesRadian[q])
              {
                  regionalMask[xy] = (int)((q+ (opticNerveZones-1))% opticNerveZones);
                  break;
              }
           }
		}
		else {
			rate[xyN] = rate_tissue_index_xy;
			rate[xyN + 1] = rate_tissue_index_xy;
			rate[xyN + 2] = rate_tissue_index_xy;
			rate[xyN + 3] = rate_tissue_index_xy;
			if (rate_dimensions > 4) {
				rate[xyN + 4] = rate_tissue_index_z;
				rate[xyN + 5] = rate_tissue_index_z;
			}
			detox[xy] = outsideDetox;
			tox_prod[xy] = outsideToxProd;
			tox_dev[xy] = 0;
			simulation_point_mask[xy] = pixelOutsideOfTissue;
			regionalMask[xy] = noOpticZone;
 		}
	}
}

//bool[,] pix_out_of_nerve = new bool[im_size, im_size];
//for (int y = 0; y < im_size; y++)
//    for (int x = 0; x < im_size; x++)
//    {
//        int dx = x - nerve_cent_pix;
//        int dy = y - nerve_cent_pix;
//        int dis2 = dx * dx + dy * dy;

//        bool outside = nerve_r_pix_2 - dis2 < 0 || vein_r_pix_2 - dis2 > 0;
//        pix_out_of_nerve[x, y] = outside;
//        if (!outside)
//        {
//            pix_idx[pix_idx_num++] = x * im_size + y;
//            for (uint k = 0; k < 4; k++)
//                rate[x, y, k] = k_rate_extra;
//            detox[x, y] = k_detox_extra;
//        }
//    }

