The approach for this is to iterate over the string, get the 'center' of the palindrome, and then check the rest of the letters using a double pointer.Center of the palindrome meaning the single letter, or total string of repeated letters (eg.aba = 'b' center, rcccr = 'ccc' center).
```
public string LongestPalindrome(string s)
{
	if (s.Length == 1) { return s; } //get rid of edge case immediately for single letter inputs

	//creating variables that will be used, and to store the longest found so far
	string currentPalindrome;
	string longestPalindrome = String.Empty;

	//we'll iterate over the given string and use a double pointer (left/right index) to evaluate the palindrome for that starting letter
	int leftIndex;
	int rightIndex;
	for (int letterIndex = 0; letterIndex < s.Length - 1; letterIndex++)
	{
		//stop if the longest found is already longer than the longest possible with remaining letters
		//unnecessary, but made it 20% more efficient with the given test cases
		if (longestPalindrome.Length / 2 > s.Length - letterIndex + 1) { break; }

		//we need to reset our variables on each new letter being evaluated
		currentPalindrome = string.Empty;
		leftIndex = letterIndex;
		rightIndex = letterIndex;

		//check if there are multiple of the same letter in a row
		if (s[letterIndex].Equals(s[letterIndex + 1]))
		{
			//if so, call the getCenter() method (see bottom of code) to get the center of palindrome
			var center = getCenter(s, rightIndex); //pass in the given string and our starting point.
			currentPalindrome = center.Item1;      //assembled center string
			rightIndex = center.Item2;             //index at end of center string
			leftIndex--;                           //adjust left index so both indexes are at the right place to continue
		}

		//avoid index out of bounds exceptions by checking against length
		//loop while index is in bounds and the left index has the same letter as the right index
		//'string.Equals()' is better for string comparisons than '=='
		while (leftIndex > -1 && rightIndex < s.Length && s[leftIndex].Equals(s[rightIndex]))
		{
			if (currentPalindrome.Equals(string.Empty))
			{
				//add the current letter if there's nothing in the palindrome we're building yet
				//if there was a repeated letter center it would already be in 'currentPalindrome',
				//so this will only be the case for single letter centers
				currentPalindrome = s[rightIndex].ToString();
			}
			else
			{
				//if there is already data in the palindrome being evaluated, add to both sides
				//there are more efficient ways to do this, but this is really clear
				currentPalindrome = s[leftIndex] + currentPalindrome + s[rightIndex];
			}

			//iterate the left and right indexes outwards to continue palindrome evaluation
			leftIndex--;
			rightIndex++;
		}

		//after getting the palindrome from that letter, if it is larger than our largest, save it
		if (currentPalindrome.Length > longestPalindrome.Length)
		{
			longestPalindrome = currentPalindrome;
		}
	}

	return longestPalindrome;
}

//helper method to get the center of a palindrome in the case of repeated characters.
//instead of trying to figure out if it's even or odd and write logic around that,
//it's easier to get the entire chunk of repeated letters and continue evaluating the from where it ends
(string, int) getCenter(string s, int currentIndex)
{
	string center = s[currentIndex].ToString();

	//add letters while the letter is the same and we're in bounds of the string
	while (currentIndex < s.Length - 1 && s[currentIndex].Equals(s[currentIndex + 1]))
	{
		center += s[currentIndex];
		currentIndex++;
	}

	//return assembled center and the new starting index for rightIndex
	//accessed with .Item1 and .Item2 as seen in the LongestPalindrome() method where this is called
	return (center, currentIndex + 1);
}
```
