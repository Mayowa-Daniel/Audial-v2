



#ifndef ADC_LIB_H_
#define ADC_LIB_H_

		#include <avr/io.h>
		#define F_CPU 16000000UL
		#include "util/delay.h"
		
		//Initialize ADC
		void ADC_init();
		
		//convert voltage reading to volume
		void volumo();
		
		
		

		
		
		
		
#endif