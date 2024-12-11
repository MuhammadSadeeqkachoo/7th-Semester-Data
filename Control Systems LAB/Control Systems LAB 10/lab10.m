num = [2 -3];
denum = [1 2 4 8];
sys = tf(num,denum);
rlocus(sys);
title('Root  locus  of  G(S)H(S)=K(s  -  2)/(s^3  +  2  s^2  +  4  s  + 8)') ; 