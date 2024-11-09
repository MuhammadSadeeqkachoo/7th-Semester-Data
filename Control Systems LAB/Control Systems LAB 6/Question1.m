clear;
clc;
syms s a t I1 I2 I3 v

%Question 1
f1 = ilaplace(3/s*(s^2 + 2*s+5));
pretty(f1);

%Question 2
f2 = ilaplace(1/s*(s+2));
pretty(f2);

%Question 3
f3 = ilaplace(1/s^2);
pretty(f3);

%Question 4
f4 = ilaplace(1/(s-a)^2);
pretty(f4);

%Question 5
f = t;
f5 = ilaplace(f);
pretty(f5);

%Question 6
f6 = ilaplace(cos(a*t));
pretty(f6);

%Question 7
f7 = ilaplace(1 + 2*exp(-t) + 3*exp(-2*t));
pretty(f7);

%Question 8
f8 = ilaplace( 2*exp(-t) - 2*t*exp(-2*t) -2*exp(-2*t));
pretty(f8);

%Question 9
f9 = 4*s^2 + 4*s + 4/(s^4 + 3*s^3 + 2*s^2);
num = [0 0 4 4 4];
dnum = [1 3 2 0 0];
[r, p, k] = residue(num,dnum);

%Question 10
A = [(2*s+2) -(2*s+1) -1;
    -(2*s+1) (9*s +1) -4*s;
    -1 4*s (4*s+1+1/s) ];

B = [I1;I2;I3];

C = [v;0;0];

B = inv(A)*C;
pretty(B);

