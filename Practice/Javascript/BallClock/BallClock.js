//BallClock script made by Kent Phan

//A Flip Container-------------------------------------------------
//Represents a flip container of a ball clock
//Input slots = size limit of the flip container
function  FlipContainer(slots)
{
	//Check input
	if(slots < 0)
		slots = 0;
	
	//Variables
	this.Stack = []; //Represent container as a stack
	this.MaxSize = slots; // Size limit of the container
	
	//Functions
	
	//Add Ball to flip container
	//If adding causes the flip container to flip. Return the flip table array and empty its contents;
	//If adding doesn't cause the flip container to flip. Return an empty array
	this.AddBall = function (ballNumber){
		//If MaxSize is exceeded
		var toReturn = [];
		if((this.Stack.length + 1) >= this.MaxSize)
		{
			this.Stack.push(ballNumber);
			toReturn = this.Stack;
			this.Stack = [];
			return toReturn;
		}
		else
		{
			this.Stack.push(ballNumber);
			return toReturn;
		}
	}
	
	//Get Contents of the flip container
	this.GetContents = function()
	{
		return this.Stack;		
	}
}

// A Ball Clock-----------------------------------------------------------------
//Initializes BallClock with the given number of balls. Balls are initialized into the queue
function BallClock(NumberOfBalls)
{
	//Variables
	this.MinuteFlip = new FlipContainer(5); 
	this.FiveMinuteFlip = new FlipContainer(12); 
	this.HourFlip = new FlipContainer(12);
	this.QueueLine = [];
	for(i=1; i <= NumberOfBalls; i++) // Initialize queue based upon given input
	{
		this.QueueLine.push(i);
	}
	
	//Functions
	
	//Gets the current state of the ball clock in JSON format
	this.GetState = function()
	{
		var toReturn = '{'
		+ "\"Min\":" + JSON.stringify(this.MinuteFlip.Stack) + ","
		+ "\"FiveMin\":" + JSON.stringify(this.FiveMinuteFlip.Stack) + ","
		+ "\"Hour\":" + JSON.stringify(this.HourFlip.Stack) + ","
		+ "\"Main\":" + JSON.stringify(this.QueueLine) 
		+ '}'
		return toReturn;
	}
	//Save Initial State
	this.InitialState = this.GetState();
	
	//Adds all of the given balls to the queue line;
	this.AddBallsToQueue = function(balls)
	{
		while(balls.length >0)
		{
			this.QueueLine.push(balls.pop());
		}
	}
	
	//Advances the BallClock a minute
	this.AdvanceMinute = function()
	{
		//Check QueueLine has balls
		if(this.QueueLine.length <=0)
		{
			alert("Unable to advance minute due to lack of balls on queue:" + this.GetState());
			return;
		}
		
		var currentBall = this.QueueLine.shift(); // Get Ball from front of queue
		
		//For every flip table as we advance forward. Add current ball to Flip container. 
		//if the flip container returns an empty array, stop.
		//if the flip container returns an array, make the current ball the top item of the array, and
		//add the rest of the items back to the queueline.
		
		var currentBalls = this.MinuteFlip.AddBall(currentBall); 
		if(currentBalls.length == 0) 
			return;
		currentBall = currentBalls.pop();
		this.AddBallsToQueue(currentBalls);
		
		currentBalls = this.FiveMinuteFlip.AddBall(currentBall);
		if(currentBalls.length == 0)
			return;
		currentBall = currentBalls.pop();
		this.AddBallsToQueue(currentBalls);
		
		currentBalls = this.HourFlip.AddBall(currentBall);
		if(currentBalls.length == 0)
			return;
		currentBall = currentBalls.pop();
		this.AddBallsToQueue(currentBalls);
		this.QueueLine.push(currentBall); //At the end, add the rest of the balls back to the queueline
		
		
	}
	
	//Run Clock for the given number of minutes
	this.RunMinutes = function(minutes)
	{
		for(i = 0; i < minutes; i++)
		{
			this.AdvanceMinute();
		}
	}
	
	//Gets the total number of possible cycles inside the ball clock before repeating
	this.GetTotalCycles = function (){
		var numberOfCycles = 0;
		var limit = 10000000000000;
		
		do{
			this.AdvanceMinute();
			numberOfCycles++;
		}
		while((this.InitialState != this.GetState()) && (numberOfCycles < limit))
		if(numberOfCycles == limit)
		{
			alert("Limit of cycles to calculate was hit");
		}
		return numberOfCycles;
	}
}