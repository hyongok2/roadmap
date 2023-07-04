#pragma once
#include <iostream>

class PainterPath
{
public:
	void begin(){}
	void end()  {}

	void draw_rect()   { std::cout << "draw rect" << std::endl; }
	void draw_circle() { std::cout << "draw circle" << std::endl; }
};

class Painter
{
public:
	void draw_path(const PainterPath& path) {}
};