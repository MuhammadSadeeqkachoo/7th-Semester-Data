num = [8 10];
den = [1 5 1 5 13];
[A,B,C,D] = tf2ss(num,den);

P = [ 0 0 0 1 ;
      0 0 1 0 ;
      0 1 0 0 ;
      1 0 0 0];

A = inv(P)*A*P
B = inv(P)*B
C = C*P