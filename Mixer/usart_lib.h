/*
 * usart_lib.h
 *
 * Created: 8/5/2021 20:35:49
 *  Author: Maya-2
 */ 

#define F_CPU 16000000UL
#define BAUD 9600UL

#ifndef USART_LIB_H_
#define USART_LIB_H_
	#include <avr/io.h>
	#include <util/delay.h> 

	void USART_init();
	void USART_TX(char * volumo);
	int converto(int val);

#endif