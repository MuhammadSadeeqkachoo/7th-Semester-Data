num = 1;
dnum = [1 3 1];

g = tf(num,dnum);

sys = feedback(g, 1);

step(sys)
hold on

kp = 2;
ki = 1;
kd = 1;

%P = pidtune(g,'pid');
P = pid(kp,ki,kd);

sys_new = feedback(P*g, 1);

step(sys_new); 
