num = [1  2 12 7 6];
den = [1 9 13 8 0 0];
[A,B,C,D] = tf2ss(num,den);

P = [ 0 0 0 0 1 ;
      0 0 0 1 0 ;
      0 0 1 0 0 ;
      0 1 0 0 0 ;
      1 0 0 0 0];

A = inv(P)*A*P
B = inv(P)*B
C = C*P