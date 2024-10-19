num = [10];
deno = [1 2 20];
t = 0:0.01:10;
h = tf(num, deno);

u = ones(size(t)); 

y1 = lsim(h, u, t);
y2 = step(h, t);  % Step response at time vector t
y3 = step(h, 5:0.01:10);  % Step response starting from t=5 to t=10

Temp = zeros(500, 1);  
y3 = [Temp; y3];  

y = y1 + y2 + y3(1:length(t));

plot(t, y);
title('System Response');
xlabel('Time (seconds)');
ylabel('Response');
