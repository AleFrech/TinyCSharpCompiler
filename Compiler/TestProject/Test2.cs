using System;
namespace System.mierda{
	public class BankAccount{

	   protected double interestRate;
	   protected string owner;
	   protected float balance;

	   public BankAccount(string o, float b, double ir) {
		  this.interestRate = ir;
		  this.owner = o; 
		  this.balance = b;
	   }

	   public int Test(int x, float y)
	   {
		   
	   }
	   
	   public virtual void Withdraw (float amount) {
		  balance -= amount;
	   }

	   public virtual void Deposit (float amount) {
		  balance += amount;
	   }

	    public int Test(int x, float y, bool p)
	   {
		   
	   }
	   
	   public virtual void AddInterests() {
		  balance += balance * (float)interestRate;
	   }    

	   public string ToString() {
		  return owner + "'s account holds " +
				+ balance + " kroner";
	   }
	}
}
