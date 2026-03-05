clc
clear

A=[2 1 -1 8;
  -3 -1 2 -11;
  -2 1 2 -3];

n=size(A,1);

for k=1:n-1
    for i=k+1:n
        t=A(i,k)/A(k,k);
        A(i,:)=A(i,:)-t*A(k,:);
    end
end

x=zeros(n,1);
x(n)=A(n,n+1)/A(n,n);

for i=n-1:-1:1
    s=0;
    for j=i+1:n
        s=s+A(i,j)*x(j);
    end
    x(i)=(A(i,n+1)-s)/A(i,i);
end

x
