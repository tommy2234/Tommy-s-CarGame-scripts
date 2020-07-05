#include<iostream>
#include<cstdlib>
using namespace std;
int main(void)
{
	int n,i,j;
	cin>>n;
	int a[n][n];
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
		{
			a[i][j]=0;
		}
	}
	int r=0,c=n/2;
	a[r][c]=1;
	for(i=2;i<=n*n;i++)
	{
		if(r>0&&c<n-1) //若右上沒出界 
		{
			if(a[r-1][c+1]==0) //若右上未填 
			{
				a[r-1][c+1]=i;
				r-=1;
				c+=1;
			}
			else if(a[r-1][c+1]!=0&&r+1<=n-1) //若右上已填且下方沒出界 
			{
				a[r+1][c]=i;
				r+=1;
			}
			else if(a[r-1][c+1]!=0&&r+1>n-1) //若右上已填且下方出界 
			{
				a[0][c]=i;
				r=0;
			}
			
		}
		else if(r==0&&c<n-1) //若僅上方出界
		{
			a[n-1][c+1]=i;
			r=n-1;
			c+=1;
		} 
		else if(r>0&&c==n-1) //若僅右方出界 
		{
			a[r-1][0]=i;
			r-=1;
			c=0;
		}
		else if(r==0&&c==n-1) //若右和上同時出界(第一列最右邊)
		{
			a[r+1][c]=i;
			r+=1;
		} 
	}
	
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
		{
			cout<<a[i][j]<<" ";
		}
		cout<<"\n";
	}
    
	system("pause");
	return 0;
}
