t = 0:0.01:10;
T = 5;
f = 1/T;

A = 2;

x = A * sin(2*pi*f*t);

x1 = step;

x2 = step(5,t);

x3 = 2*step(sys,5,t);

y1 = lsim();