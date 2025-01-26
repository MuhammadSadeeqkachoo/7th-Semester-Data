% Define the system matrices
A = [4 0; 0 1];
B = [0.4; 0.3];
C = [1 0];
D = 0;

% Display the matrices
disp('Matrix A:');
disp(A);

disp('Matrix B:');
disp(B);

disp('Matrix C:');
disp(C);

disp('Matrix D:');
disp(D);

% Compute the eigenvalues of matrix A
eigenvalues = eig(A);
disp('Eigenvalues of A:');
disp(eigenvalues);

% Create the state-space system
sys = ss(A, B, C, D);

% Find and display the poles of the system
poles = pole(sys);
disp('Poles of the system:');
disp(poles);

% Plot the pole-zero map
figure;
pzmap(sys);
title('Pole-Zero Map of the System');

% Convert state-space to transfer function
[num, den] = ss2tf(A, B, C, D);

% Create the transfer function
G = tf(num, den);

% Plot the root locus
figure;
rlocus(G);
title('Root Locus of the System');

% Plot the step response
figure;
step(sys);
title('Step Response of the System');

% Compute the controllability matrix
C_matrix = ctrb(A, B);

% Display the controllability matrix
disp('Controllability Matrix:');
disp(C_matrix);

% Check the rank of the controllability matrix
rank_C = rank(C_matrix);

% Display the rank
disp('Rank of the Controllability Matrix:');
disp(rank_C);

% Check controllability
if rank_C == size(A, 1)
    disp('The system is controllable.');
else
    disp('The system is NOT controllable.');
end

% Compute the observability matrix
O_matrix = obsv(A, C);

% Display the observability matrix
disp('Observability Matrix:');
disp(O_matrix);

% Check the rank of the observability matrix
rank_O = rank(O_matrix);

% Display the rank
disp('Rank of the Observability Matrix:');
disp(rank_O);

% Check observability
if rank_O == size(A, 1)
    disp('The system is observable.');
else
    disp('The system is NOT observable.');
end

% Step 1: Controllability Matrix P
P = [B A*B];

% Display the rank of the controllability matrix
disp('The rank of matrix P is:');
disp(rank(P));

% Step 2: Observability Matrix Q
Q = [C; C*A];

% Display the rank of the observability matrix
disp('The rank of matrix Q is:');
disp(rank(Q));


% Step 4: State Feedback Design (using pole placement for state feedback)
desired_state_feedback_poles = [-4 -16];  % Desired state feedback poles
K = place(A, B, desired_state_feedback_poles);  % State feedback gain K
disp('State feedback gain K:');
disp(K);

A_cl = A - B * K

disp("Eigenvalues of the closed-loop system:")
disp(eig(A_cl))


sys_cl = ss(A_cl, B, C, D);
figure;
step(sys_cl);
title("Step Response of Closed-Loop System");