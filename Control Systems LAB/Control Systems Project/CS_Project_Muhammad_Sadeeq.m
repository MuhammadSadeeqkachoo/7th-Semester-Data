% Define the system matrices
A = [4 0; 0 1];
B = [0.4; 0.3];
C = [1 0];
D = 0;

% Method 1: Eigenvalues of A
disp('Method 1: Eigenvalues of A:');
eig_A = eig(A);
disp(eig_A);

% Method 2: Poles of the system
disp('Method 2: Poles of the system:');
sys = ss(A, B, C, D); % State-space system
poles = pole(sys);
disp(poles);

% Method 3: Pole-Zero Map
figure;
pzmap(sys);
title('Pole-Zero Map');

% Method 4: Root Locus
figure;
rlocus(sys);
title('Root Locus');

% Method 5: Step Response
figure;
step(sys);
title('Step Response of the Open-Loop System');

% Method 6: Routh-Hurwitz Table
disp('Method 6: Routh-Hurwitz Table:');
syms s
characteristic_poly = det(s * eye(2) - A); % Characteristic polynomial
coeffs_poly = coeffs(characteristic_poly, s, 'all'); % Polynomial coefficients
disp('Characteristic Polynomial Coefficients:');
disp(coeffs_poly);


%% 
% Controllability Test
P = ctrb(A, B);
rank_C = rank(P);
disp(['Rank of Controllability Matrix: ', num2str(rank_C)]);
if rank_C == size(A, 1)
    disp('The system is controllable.');
else
    disp('The system is NOT controllable.');
end

% Observability Test
Q = obsv(A, C);
rank_O = rank(Q);
disp(['Rank of Observability Matrix: ', num2str(rank_O)]);
if rank_O == size(A, 1)
    disp('The system is observable.');
else
    disp('The system is NOT observable.');
end

%%
% Convert state-space to transfer function
[num, den] = ss2tf(A, B, C, D);

% Create the transfer function
G = tf(num, den);

% Design a PID controller using pidtune
[PID, info] = pidtune(G, 'PID');

% Display the tuned PID controller
disp('Tuned PID Controller:');
disp(PID);

% Closed-loop system with PID controller
sys_cl = feedback(PID * G, 1);

% Step response of the closed-loop system
figure;
step(sys_cl);
title('Step Response with Tuned PID Controller');

%%
syms s
G_cl_sym = poly2sym(cell2mat(sys_cl.Numerator), s) / poly2sym(cell2mat(sys_cl.Denominator), s);

% Step Input Error
ess_step = double(limit(1 / (1 + G_cl_sym), s, 0));

% Ramp Input Error
ess_ramp = double(limit(s / (1 + G_cl_sym), s, 0));

% Display Results
fprintf('Steady-State Errors with PID Controller:\n');
fprintf('Step Input Error: %f\n', ess_step);
fprintf('Ramp Input Error: %f\n', ess_ramp);

