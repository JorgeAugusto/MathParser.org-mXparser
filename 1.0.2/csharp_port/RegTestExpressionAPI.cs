/*
 * @(#)RegTestExpressionAPI.cs        1.0    2010-02-20
 * 
 * You may use this software under the condition of "Simplified BSD License"
 * 
 * Copyright 2010 MARIUSZ GROMADA. All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 * 
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 * 
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY <MARIUSZ GROMADA> ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of MARIUSZ GROMADA.
 * 
 * If you have any questions/bugs feel free to contact:
 * 
 *     Mariusz Gromada
 *     mariusz.gromada@mathspace.pl
 *     http://mathspace.pl/
 *     http://mxparser.sourceforge.net/
 * 
 *                              Asked if he believes in one God, a mathematician answered: 
 *                              "Yes, up to isomorphism."  
 */ 

using System;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace org.mariuszgromada.math.mxparser.regressiontesting
{



    /**
     * RegTestExpressionAPI - regression tests for the expression API
     * 
     * @author         <b>Mariusz Gromada</b><br/>
     *                 <a href="mailto:mariusz.gromada@mathspace.pl">mariusz.gromada@mathspace.pl</a><br>
     *                 <a href="http://mathspace.pl/">http://mathspace.pl/</a><br>
     *                 <a href="http://mxparser.sourceforge.net/">http://mxparser.sourceforge.net/</a><br>
     *                         
     * @version        1.0
     * 
     * @see Expression
     */
    public class RegTestExpressionAPI
    {

        /**
         * @param args
         */
        public static void Start(String[] args) {

        long start = mXparser.currentTimeMillis();
		
		bool syn1, syn2, syn3, syn4, syn5, syn6, syn7, syn8, b1, b2, b3;
		String s1, s2;
		int i1, i2, n1, n2, n3, n4, n5, n6;
		
		Argument A1, A2, A3, A4, A5;
		Function F1, F2, F3, F4, F5;
		Constant C1, C2, C3, C4, C5;
		double d1, d2, d3;
		
		Constant c1 = new Constant("c1",1);
		Constant c2 = new Constant("c2",2);
		Constant c3 = new Constant("c3",3);
		//Constant c4 = new Constant("c4",4);
		Constant c5 = new Constant("c5",5);
		Constant c6 = new Constant("c6",6);
		
		Function f1 = new Function("f1","1","x");
		Function f2 = new Function("f2","2","x");
		Function f3 = new Function("f3","3","x");
		Function f4 = new Function("f4","4","x");
		//Function f5 = new Function("f5","5","x");
		Function f6 = new Function("f6","6","x");
		Function f7 = new Function("f7","7","x");
		
		Argument a1 = new Argument("a1",1); 
		Argument a2 = new Argument("a2",2); 
		Argument a3 = new Argument("a3",3);
		Argument a4 = new Argument("a4",4);
		Argument a5 = new Argument("a5",5);
		Argument a6 = new Argument("a6",6);
		Argument a7 = new Argument("a7",7);
		//Argument a8 = new Argument("a8",8);
		
		List<Constant> constants = new List<Constant>();
		List<Function> functions = new List<Function>();
		List<Argument> arguments = new List<Argument>();
		
		constants.Add(c1);
		constants.Add(c2);
		constants.Add(c3);
		
		functions.Add(f1);
		functions.Add(f2);
		functions.Add(f3);
		functions.Add(f4);
		
		arguments.Add(a1);
		arguments.Add(a2);
		arguments.Add(a3);
		arguments.Add(a4);
		arguments.Add(a5);
		
		bool[] test = new bool[100];
		for (int i = 0; i < 100; i++)
			test[i] = false;
		
		Expression e;
		int testId = -1;
		
		/*
		 * 0. public Expression()
		 */
		testId++;
		e = new Expression();
		if (	e.getExpressionString().Equals("")
				&& e.getArgumentsNumber() == 0
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 0	)
			test[testId] = true;
		
		
		/*
		 * 1. Expression(String expressionString, List<Argument> argumentsList)
		 */
		testId++;
		e = new Expression("a1+c2", arguments);
		if (	e.getExpressionString().Equals("a1+c2")
				&& e.getArgumentsNumber() == 5
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 0	)
			test[testId] = true;
		
		/*
		 * 2. Expression(String expressionString, List<Argument> argumentsList,
		 *               List<Function> functionsList)
		 */
		testId++;
		e = new Expression("a1+c2", arguments, functions);
		if (	e.getExpressionString().Equals("a1+c2")
				&& e.getArgumentsNumber() == 5
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 4	)
			test[testId] = true;
		
		/*
		 * 3. Expression(String expressionString, List<Argument> argumentsList,
		 * List<Function> functionsList, List<Constant> constantsList)
		 */
		testId++;
		e = new Expression("a1+c2", arguments, functions, constants);
		if (	e.getExpressionString().Equals("a1+c2")
				&& e.getArgumentsNumber() == 5
				&& e.getConstantsNumber() == 3
				&& e.getFunctionsNumber() == 4	)
			test[testId] = true;
		
		/*
		 * 4. void setExpressionString(String expressionString), String getExpressionString(), void clearExpressionString()	
		 */
		testId++;		
		syn1 = e.checkSyntax();
		e.setExpressionString("c2+a1");
		syn2 = e.getSyntaxStatus();
		syn3 = e.checkSyntax();
		s1 = e.getExpressionString();
		syn4 = e.getSyntaxStatus();
		syn5 = e.checkSyntax();
		e.clearExpressionString();
		syn6 = e.getSyntaxStatus();
		syn7 = e.checkSyntax();
		s2 = e.getExpressionString();
		syn8 = e.getSyntaxStatus();
		
		
		if (	s1.Equals("c2+a1")
				&& s2.Equals("")
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.NO_SYNTAX_ERRORS
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn7 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn8 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				
				
				)
			test[testId] = true;
		
		/*
		 * 5. void setDescription(String description), String getDescription(), void clearDescription() 
		 */
		testId++;
		e.setExpressionString("c1+a2");
		syn1 = e.checkSyntax();
		e.setDescription("opis");
		s1 = e.getDescription();
		e.clearDescription();
		s2 = e.getDescription();
		syn2 = e.getSyntaxStatus();
		if (	s1.Equals("opis")
				&& s2.Equals("")	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS
				)
			test[testId] = true;
		
		/*
		 * 6. void setVerboseMode(), bool getVerboseMode(), void setSilentMode()
		 */
		testId++;
		syn1 = e.checkSyntax();
		b1 = e.getVerboseMode();
		e.setVerboseMode();
		b2 = e.getVerboseMode();
		e.setSilentMode();
		b3 = e.getVerboseMode();
		syn2 = e.getSyntaxStatus();
		if (	b1 == false
				&& b2 == true
				&& b3 == false	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS
				)
			test[testId] = true;
	
		/*
		 * 7.
		 * public void setRecursiveMode()
		 * public void disableRecursiveMode()
		 * public bool getRecursiveMode()
		 */
		testId++;
		syn1 = e.checkSyntax();
		b1 = e.getRecursiveMode();
		e.setRecursiveMode();
		b2 = e.getRecursiveMode();
		e.disableRecursiveMode();
		b3 = e.getRecursiveMode();
		syn2 = e.getSyntaxStatus();
		if (	b1 == false
				&& b2 == true
				&& b3 == false	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS
				)
			test[testId] = true;
		
		
		
		/*
		 * 8.
		 * Expression(String expressionString)
		 */
		testId++;
		e = new Expression("1+2");
		if (	e.getExpressionString().Equals("1+2")
				&& e.getArgumentsNumber() == 0
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 0	)
			test[testId] = true;
		
		/*
		 * 9.
		 * Expression(String expressionString)
		 */
		testId++;
		e = new Expression("1+2", a1, a2, a3);
		if (	e.getExpressionString().Equals("1+2")
				&& e.getArgumentsNumber() == 3
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 0	)
			test[testId] = true;		
				
		/*
		 * 10.
		 * void addArguments(Argument... arguments)
		 * void addArguments( List<Argument> argumentsList)
		 * defineArguments(String... argumentsNames)
		 * defineArgument(String argumentName, double argumentValue)
		 */
		testId++;
		e = new Expression("1+2");
		syn1 = e.checkSyntax();
		e.addArguments(a6, a7);
		syn2 = e.getSyntaxStatus();
		syn3 = e.checkSyntax();
		e.addArguments(arguments);
		syn4 = e.getSyntaxStatus();
		syn5 = e.checkSyntax();
		e.defineArguments("x1", "x2", "x3");
		syn6 = e.getSyntaxStatus();
		syn7 = e.checkSyntax();
		e.defineArgument("x", 1);
		syn8 = e.getSyntaxStatus();
		
		if (	e.getExpressionString().Equals("1+2")
				&& e.getArgumentsNumber() == 11
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 0
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn7 == Expression.NO_SYNTAX_ERRORS
				&& syn8 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
					)
			test[testId] = true;		
		
		
		/*
		 * 11.
		 * int getArgumentIndex(String argumentName)
		 * Argument getArgument(String argumentName)
		 * Argument getArgument(int argumentIndex)
		 * int getArgumentsNumber()
		 */
		testId++;
		syn1 = e.checkSyntax();
		i1 = e.getArgumentIndex("asdsa"); //-1
		i2 = e.getArgumentIndex("x1"); //7
		A1 = e.getArgument("asasas"); //null
		A2 = e.getArgument("a2"); //a2
		A3 = e.getArgument(-1); //null
		A4 = e.getArgument(23);//null
		A5 = e.getArgument(1);//a7
		n1 = e.getArgumentsNumber();//11
		syn2 = e.getSyntaxStatus();
		if (	i1 == -1
				&& i2 == 7
				&& A1 == null
				&& A2 == a2
				&& A3 == null
				&& A4 == null
				&& A5 == a7
				&& n1 == 11
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS				
				)
			test[testId] = true;		
		
		/*
		 * 12.
		 * void setArgumentValue
		 * double getArgumentValue
		 */
		testId++;
		syn1 = e.checkSyntax();
		d1 = e.getArgumentValue("a1");
		syn2 = e.getSyntaxStatus();
		e.setArgumentValue("asds", 1);
		syn3 = e.getSyntaxStatus();
		syn4 = e.checkSyntax();
		e.setArgumentValue("a1", 10);
		syn4 = e.getSyntaxStatus();
		d2 = e.getArgumentValue("asdfasdf");
		d3 = e.getArgumentValue("a1");
		syn5 = e.getSyntaxStatus();
		
		if (	d1 == 1
				&& Double.IsNaN(d2)
				&& d3 == 10
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.NO_SYNTAX_ERRORS
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				)
			test[testId] = true;		
		
		/*
		 * 13.
		 * void removeArguments(String... argumentsNames)
		 * void removeArguments(Argument... arguments)
		 * void removeAllArguments()
		 */
		testId++;
		e.setExpressionString("1+2");
		syn1 = e.checkSyntax();
		n1 = e.getArgumentsNumber();
		e.removeArguments("asfdf");
		syn2 = e.getSyntaxStatus();
		n2 = e.getArgumentsNumber();
		e.removeArguments("x1","x2");
		n3 = e.getArgumentsNumber();
		syn3 = e.checkSyntax();
		e.removeArguments(a3);
		n4 = e.getArgumentsNumber();
		e.removeArguments(a1,a2);
		syn4 = e.getSyntaxStatus();
		n5 = e.getArgumentsNumber();
		syn5 = e.checkSyntax();
		e.removeAllArguments();
		n6 = e.getArgumentsNumber();
		syn6 = e.getSyntaxStatus();
		if (	n2 == n1
				&& n2-n3 == 2
				&& n3-n4 == 1
				&& n4-n5 == 2
				&& n6 == 0	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				)
			test[testId] = true;
		

		
		/*
		 * 14.
		 * void addConstants(Constant... constants)
		 * void addConstants( List<Constant> constantsList)
		 * void defineConstant(String constantName, double constantValue)
		 */
		testId++;
		e = new Expression("1+2");
		syn1 = e.checkSyntax();
		e.addConstants(c5, c6);
		syn2 = e.getSyntaxStatus();
		syn3 = e.checkSyntax();
		e.addConstants(constants);
		syn4 = e.getSyntaxStatus();
		syn5 = e.checkSyntax();
		e.defineConstant("cx1",1);
		e.defineConstant("cx2",2);
		e.defineConstant("cx3",3);
		syn6 = e.getSyntaxStatus();
		
		if (	e.getExpressionString().Equals("1+2")
				&& e.getArgumentsNumber() == 0
				&& e.getConstantsNumber() == 8
				&& e.getFunctionsNumber() == 0
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
					)
			test[testId] = true;		
		
		
		/*
		 * 15.
		 * int getConstantIndex(String constantName)
		 * Constant getConstant(String constantName)
		 * Constant getConstant(int constantIndex)
		 * int getConstantsNumber()
		 */
		testId++;
		syn1 = e.checkSyntax();
		i1 = e.getConstantIndex("asdsa"); //-1
		i2 = e.getConstantIndex("c6"); //1
		C1 = e.getConstant("asasas"); //null
		C2 = e.getConstant("c1"); //c1
		C3 = e.getConstant(-1); //null
		C4 = e.getConstant(23);//null
		C5 = e.getConstant(0);//c5
		n1 = e.getConstantsNumber();//8
		syn2 = e.getSyntaxStatus();
		if (	i1 == -1
				&& i2 == 1
				&& C1 == null
				&& C2 == c1
				&& C3 == null
				&& C4 == null
				&& C5 == c5
				&& n1 == 8
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS				
				)
			test[testId] = true;		
		
		
		/*
		 * 16.
		 * void removeConstants(String... constantsNames)
		 * void removeConstants(Constant... constants)
		 * void removeAllConstants()
		 */
		testId++;
		e.setExpressionString("1+2");
		syn1 = e.checkSyntax();
		n1 = e.getConstantsNumber();
		e.removeConstants("asfdf");
		syn2 = e.getSyntaxStatus();
		n2 = e.getConstantsNumber();
		e.removeConstants("cx1","cx2");
		n3 = e.getConstantsNumber();
		syn3 = e.checkSyntax();
		e.removeConstants(c1);
		n4 = e.getConstantsNumber();
		e.removeConstants(c2,c3);
		syn4 = e.getSyntaxStatus();
		n5 = e.getConstantsNumber();
		syn5 = e.checkSyntax();
		e.removeAllConstants();
		n6 = e.getConstantsNumber();
		syn6 = e.getSyntaxStatus();
		
		if (	n2 == n1
				&& n2-n3 == 2
				&& n3-n4 == 1
				&& n4-n5 == 2
				&& n6 == 0	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				)
			test[testId] = true;
		
		/*
		 * 17.
		 * void addFunctions(Function... functions) 
		 * void addFunctions( List<Function> functionsList)
		 * void defineFunction(String functionName, String  functionExpressionString,...
		 */
		testId++;
		e = new Expression("1+2");
		syn1 = e.checkSyntax();
		e.addFunctions(f6, f7);
		syn2 = e.getSyntaxStatus();
		syn3 = e.checkSyntax();
		e.addFunctions(functions);
		syn4 = e.getSyntaxStatus();
		syn5 = e.checkSyntax();
		e.defineFunction("ff1", "1", "x");
		syn6 = e.getSyntaxStatus();
			
		if (	e.getExpressionString().Equals("1+2")
				&& e.getArgumentsNumber() == 0
				&& e.getConstantsNumber() == 0
				&& e.getFunctionsNumber() == 7
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
					)
			test[testId] = true;		
		
		
		/*
		 * 18.
		 * int getFunctionIndex(String functionName)
		 * Function getFunction(String functionName)
		 * Function getFunction(int functionIndex)
		 * int getFunctionsNumber()
		 */
		testId++;
		syn1 = e.checkSyntax();
		i1 = e.getFunctionIndex("asdsa"); //-1
		i2 = e.getFunctionIndex("f7"); //1
		F1 = e.getFunction("asasas"); //null
		F2 = e.getFunction("f1"); //f1
		F3 = e.getFunction(-1); //null
		F4 = e.getFunction(23);//null
		F5 = e.getFunction(0);//f6
		n1 = e.getFunctionsNumber();//7
		syn2 = e.getSyntaxStatus();
		if (	i1 == -1
				&& i2 == 1
				&& F1 == null
				&& F2 == f1
				&& F3 == null
				&& F4 == null
				&& F5 == f6
				&& n1 == 7
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS				
				)
			test[testId] = true;		
		
		/*
		 * 19.
		 * void removeFunctions(String... functionsNames)
		 * void removeFunctions(Function... functions)
		 * void removeAllFunctions()
		 */
		testId++;
		e.setExpressionString("1+2");
		syn1 = e.checkSyntax();
		n1 = e.getFunctionsNumber();
		e.removeFunctions("asfdf");
		syn2 = e.getSyntaxStatus();
		n2 = e.getFunctionsNumber();
		e.removeFunctions("f1","f2");
		n3 = e.getFunctionsNumber();
		syn3 = e.checkSyntax();
		e.removeFunctions(f3);
		n4 = e.getFunctionsNumber();
		e.removeFunctions(f6,f7);
		syn4 = e.getSyntaxStatus();
		n5 = e.getFunctionsNumber();
		syn5 = e.checkSyntax();
		e.removeAllFunctions();
		n6 = e.getFunctionsNumber();
		syn6 = e.getSyntaxStatus();
		
		
		
		if (	n2 == n1
				&& n2-n3 == 2
				&& n3-n4 == 1
				&& n4-n5 == 2
				&& n6 == 0	
				&& syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn3 == Expression.NO_SYNTAX_ERRORS
				&& syn4 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				&& syn5 == Expression.NO_SYNTAX_ERRORS
				&& syn6 == Expression.SYNTAX_ERROR_OR_STATUS_UNKNOWN
				)
			test[testId] = true;
		
		
		/*
		 * 20.
		 * double calculate()
		 * String getHelp()
		 * String getHelp(String word) 
		 * String getLicense()
		 */
		testId++;
		syn1 = e.checkSyntax();
		d1 = e.calculate();
		syn2 = e.getSyntaxStatus();
		
		if (	syn1 == Expression.NO_SYNTAX_ERRORS
				&& syn2 == Expression.NO_SYNTAX_ERRORS
				&& d1 == 3)
			test[testId] = true;
		
        long end =  mXparser.currentTimeMillis();
		
		int nOk = 0;
		int nError = 0;
		
		for (int i = 0; i <= testId; i++) {
			
			if (test[i]) {
				nOk++;
                Console.WriteLine("[" + i + "] " + "OK");
			} else {
				nError++;
				Console.WriteLine("[" + i + "] " + "ERROR");
			}
			
		}
		

		Console.WriteLine("OK : " + nOk + ", ERRORs: " + nError + ", total time: " + (end-start)/1000.0 + " s.");
		
		for (int i = 0; i <= testId; i++) {
			
			
			if (!test[i])
				Console.WriteLine("ERROR: " + testId);
			
			
		}

		
	}


    }

}