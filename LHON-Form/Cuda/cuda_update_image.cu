
__device__ void setColor(int showRGBSox, float f, unsigned char& red, unsigned char& green, unsigned char& blue) {
	red = (unsigned char)(f); // 0 - 255
	if (showRGBSox) {
		if (f == 0) { red = 0; green = 0; blue = 0; }
		else if (f < 32) { red = 0; green = 0; blue = f * 8; }
	    else if (f < 64) { red = 0; green = 4 * f; blue = 255; }
		else if (f < 128) { red = 0; blue = 255 + 4 * (64 - f); green = 255; }
		else if (f < 192) { red = 4 * (f - 128); blue = 0; green = 255; }
		else { green = 255 + 4 * (192 - f); blue = 0; red = 255; }
#if 0
		float gt = f - red;
		if (red < 32) {
			red = red * 4;
			green = red;
		}
		if (red == 0) {
			float g = gt * 255;
			green = (unsigned char)(g);
			red = green;
			gt = g- green;
			if (green == 0) {
				blue = (unsigned char)(gt * 255);
			}
		}
#endif
	}
}

#define AXON_DISPLAY_HEALTHY 1
#define AXON_DISPLAY_STRESS 2
#define AXON_DISPLAY_DEAD 0

#define GLIA_DISPLAY_HEALTHY 5
#define GLIA_DISPLAY_STRESS 6
#define GLIA_DISPLAY_DEAD 4

#define HEALTHY_GREEN 230
#define STRESS_GREEN 127
#define DEAD_BLUE 255


/**

			show_opts[0] = chk_show_live_axons.Checked;
			show_opts[1] = chk_show_dead_axons.Checked;
			show_opts[2] = chk_show_stress.Checked;
			show_opts[3] = chk_show_tox.Checked;
			show_opts[4] = checkBox_show_rgc.Checked;
			show_opts[5] = checkBox_show_glia.Checked;
*/

extern "C" __global__  void cuda_update_image(unsigned short im_size, 
	unsigned short bmp_im_size, 
	float bmp_image_compression_ratio, 
	float bmp_z_compression_ratio,
	unsigned char* bmp, 
	float* bmp_tox, 
	float* tox, 
	unsigned char* simulation_point_mask, 
	unsigned char* init_insult_mask, 
	float tox_max, 
	bool* show_opts, 
	int showdir, 
	int lineToDisplay, 
	int imsq, 
	int head, 
	int no3d, 
	int showRGBSox, 
	int displayAtTop, 
	unsigned int* img_axon_center, 
	unsigned int* img_glia_center,
	float prodConv)
{
	int x_bmp = blockIdx.x * blockDim.x + threadIdx.x;
	int y_bmp = blockIdx.y * blockDim.y + threadIdx.y;

	if (x_bmp < bmp_im_size && y_bmp > 0) {

		int xy_bmp = x_bmp * bmp_im_size + y_bmp;
		int xy4_bmp = xy_bmp * 4;
		

		unsigned char red = 0, green = 0, blue = 0;
		float tox_pix_value = 0;
		
		switch (showdir) {
		case 1: { 
			// XZ (vertical slider)
			//green = blue = 0;

			if (displayAtTop) {
				if (show_opts[3]) {
					float xf = x_bmp * bmp_z_compression_ratio;
					int layer = (head+(int)(xf)) % (no3d + 2);
					int xpos = (int)((float)(bmp_im_size - lineToDisplay) * bmp_image_compression_ratio);
					int ypos = (int)((float)y_bmp * bmp_image_compression_ratio);
					int xy = ypos * im_size + xpos;
					//int xy = xpos * im_size + ypos;
					tox_pix_value = tox[xy + imsq * layer];
					float tmp = tox_pix_value / tox_max;
					if (tmp > 1) tmp = 1;
					setColor(showRGBSox, tmp * 255, red, green, blue);
				}
			}
			else {
				if ((x_bmp >= lineToDisplay) && (x_bmp < lineToDisplay + (no3d>1?no3d:1)) && show_opts[3]) {
					int layer = (head + x_bmp - lineToDisplay) % (no3d + 2);
					int xpos = (int)((float)(bmp_im_size - lineToDisplay) * bmp_image_compression_ratio);
					int ypos = (int)((float)y_bmp * bmp_image_compression_ratio);
					int xy = ypos * im_size + xpos;
					//int xy = xpos * im_size + ypos;
					tox_pix_value = tox[xy + imsq * layer];
					float tmp = tox_pix_value / tox_max;
					if (tmp > 1) tmp = 1;
					setColor(showRGBSox, tmp * 255, red, green, blue);
					//red = 255;
				}
			}
			break;
		}
		case 2: {
			// YZ (horizontal slider)
			//green = blue = 0;
			if (displayAtTop) {
				if (show_opts[3]) {
					float yf = y_bmp * bmp_z_compression_ratio;
					int layer = (head + (int)(yf)) % (no3d + 2);
					int xpos = (int)((float)(bmp_im_size - x_bmp) * bmp_image_compression_ratio);
					int ypos = (int)((float)lineToDisplay * bmp_image_compression_ratio);
					int xy = ypos * im_size + xpos;
					//int xy = xpos * im_size + ypos;
					tox_pix_value = tox[xy + imsq * layer];
					float tmp = tox_pix_value / tox_max;
					if (tmp > 1) tmp = 1;
					setColor(showRGBSox, tmp * 255, red, green, blue);
				}
			}
			else {
				if ((y_bmp >= lineToDisplay) && (y_bmp < lineToDisplay + (no3d > 1 ? no3d : 1)) && show_opts[3]) {
					int layer = (head + y_bmp - lineToDisplay) % (no3d + 2);
					int xpos = (int)((float)(bmp_im_size - x_bmp) * bmp_image_compression_ratio);
					int ypos = (int)((float)lineToDisplay * bmp_image_compression_ratio);
					int xy = ypos * im_size + xpos;
					//int xy = xpos * im_size + ypos;
					tox_pix_value = tox[xy + imsq * layer];
					float tmp = tox_pix_value / tox_max;
					if (tmp > 1) tmp = 1;
					setColor(showRGBSox, tmp * 255, red, green, blue);
				}
			}
			break;
		}
		default: {
			int xpos = (int)((float)(bmp_im_size - x_bmp) * bmp_image_compression_ratio);
			int ypos = (int)((float)y_bmp * bmp_image_compression_ratio);
			int xy = ypos * im_size + xpos;
			//int xy = xpos * im_size + ypos;
			tox_pix_value = tox[imsq * lineToDisplay + xy];
			float tmp = tox_pix_value / tox_max;
			if (tmp > 1) tmp = 1;
			
			
			if (show_opts[0]) {
				if (show_opts[4] && (simulation_point_mask[xy] == AXON_DISPLAY_HEALTHY || simulation_point_mask[img_axon_center[xy_bmp]] == AXON_DISPLAY_HEALTHY)) { green = HEALTHY_GREEN; } // rgc healthy
				if (show_opts[5] && (simulation_point_mask[xy] == GLIA_DISPLAY_HEALTHY || simulation_point_mask[img_glia_center[xy_bmp]] == GLIA_DISPLAY_HEALTHY)) { green = HEALTHY_GREEN; } // glia healthy

																																												   //if (simulation_point_mask[xy] == 2) { green = 0; } // dead
				//blue = 0;
			}
			if (show_opts[1]) {
				//if (simulation_point_mask[xy] == 1) { blue = 0; } // live
				if (show_opts[4] && (simulation_point_mask[xy] == AXON_DISPLAY_DEAD || simulation_point_mask[img_axon_center[xy_bmp]] == AXON_DISPLAY_DEAD)) { blue = DEAD_BLUE; } // rgc dead
				if (show_opts[5] && (simulation_point_mask[xy] == GLIA_DISPLAY_DEAD || simulation_point_mask[img_glia_center[xy_bmp]] == GLIA_DISPLAY_DEAD)) { blue = DEAD_BLUE; } // glia dead

																																												  //green = 0;
			}
			if (show_opts[2]) {
				//if (simulation_point_mask[xy] == 1) { blue = 0; } // live
				if (show_opts[4] && (simulation_point_mask[xy] == AXON_DISPLAY_STRESS || simulation_point_mask[img_axon_center[xy_bmp]] == AXON_DISPLAY_STRESS )) { green = STRESS_GREEN; } // stress
				if (show_opts[5] && (simulation_point_mask[xy] == GLIA_DISPLAY_STRESS || simulation_point_mask[img_glia_center[xy_bmp]] == GLIA_DISPLAY_STRESS)) { green = STRESS_GREEN; } // stress

																																												   //green = 0;
			}


			if (show_opts[3]) {
				if (show_opts[4] == 0 && show_opts[5] == 0) {
					setColor(showRGBSox, tmp * 255, red, green, blue);
				}
				else {
					red = (unsigned char)(tmp * 255); // 0 - 255
				}
				// green = 255 - normalized_toxin;
			}
			//else { red = 0; }

			if (init_insult_mask[xy_bmp]) { red = blue = green = 255; /*red = 0;*/ }
			
		}
		}
		

		bmp[xy4_bmp] = blue;
		bmp[xy4_bmp + 1] = green;
		bmp[xy4_bmp + 2] = red;

		bmp_tox[xy_bmp] = tox_pix_value*prodConv;
	}
}

/*

// Jet colormap: https://www.mathworks.com/help/matlab/ref/jet.html

if (normalized_toxin < 64) { r = 0; g = 4 * v; b = 255; }
else if (normalized_toxin < 128) { r = 0; b = 255 + 4 * (64 - v); g = 255; }
else if (normalized_toxin < 192) { r = 4 * (v - 128); b = 0; g = 255; }
else { g = 255 + 4 * (192 - normalized_toxin); b = 0; r = 255; }

*/
