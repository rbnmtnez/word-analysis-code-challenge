# word-analysis-code-challenge

## Challenge
Word analysis: In order to estimate how much we will charge a customer for a translation, and how much we will need to pay our translators for the translation work performed – we use a concept called a word analysis. 

This task is about extracting a word analysis from an external file.  
We have provided 3 different types of external word analysis files (see ExtWordAnalysis folder), but we only want you to implement the actual processing of the CSV file type. 
However please prepare the code structure for being able to extend the implementation to cover the 2 remaining file types as well.


**REST API:**

Implement the API as specified in the provided Swagger file (see Azure Files Test Data) 
For your convenience we provide a few csv test files via links to AzureFiles (see Azure Files Test Data)


**Processing:**

Determine the analysis type based on the file extension of the external file . 

The csv analysis type files contains one or more analysis result sections 
 
For each analysis result section:
Collect the number of “Source Words” from the following match categories:
•	Repetition
•	101% (context match)
•	100%
•	95%-99%
•	85%-94%
•	75%-84%
•	50%-74%
•	No match
and calculate the Total source words for the analysis result section

Summarize the match categories + Total source words across the analysis result sections found to arrive at the overall word analysis for all the sections 

Delivery of the result:

The overall word analysis result needs to be delivered on the callback specified in the swagger contract

  
What we want you to do
- Create clean code, with good practices, following standards and good principles and design patterns. Readability.  
- Create a clean architecture. Easy to open and understand what the project is about.  
- Make sure you satisfy the requirements.  
- Submit your solution.
- A brief comment on what you think about the test, and how much time you spend on it would be appreciated.   
    
Considerations
- Time is important but not the most!. 
- There is no need to rush a solution, but on the other hand it cannot take forever either, so please find a good balance. 

## Solution
The solution is implemented using the asynchronous request-reply pattern, decoupling the request reception from the processing.
A Web API is created to receive the request and an Azure Function to process it. The communication between the API and the Azure function is done with an Azure Queue.

### Other solution considerations
All projects are dotnet 5 projects, followind best practices and using design patterns.
Easy to extend just creating a service that implements IWordAnalysisService.
A retry pattern is included using Polly to handle transient failures.

## Usage 
Make sure Azure Storage Emulator is installed in your computer: https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator
Execute the Web API (WordAnalysis.Host) and the Azure Function (WordAnalysis.Jobs).
