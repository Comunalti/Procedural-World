using System;
using UnityEngine;
//Names patterns: English

// Assets names: Snake_Case with PascalCase - This_Is_An_Example_Of_Assets_Names
// Directory names: PascalCase
namespace NameOfDirectory
{
    // Class names: PascalCase
    public class ProjectPattern : MonoBehaviour //Serializable
    {
        // Attributes - camelCase
        private TestClass reference = new TestClass();
        private int serializableAttribute;
        private double genericCalculation;
        
        // Methods - PascalCase
        /// <summary>
        /// Generic method that uses other intern methods
        /// </summary>
        /// <param name="param">Anything</param>
        /// <param name="genericTestClass"></param>
        public void GenericMethod(int param, TestClass genericTestClass)
        {
            var genericVar = 0;
            ReturnCondition(param);
        }
        
        /// <summary>
        /// Return true or false according to a complex calculation result
        /// </summary>
        /// <param name="complicatedCalculationResult"></param>
        /// <returns></returns>
        private bool ReturnCondition(int complicatedCalculationResult)
        {
            return false;
        }
        
        /// <summary>
        /// Document of the method
        /// </summary>
        /// <param name="intNumber"></param>
        /// <param name="doubleNumber"></param>
        /// <returns></returns>
        private int ComplexCalculationWithGoodName(int intNumber, double doubleNumber)
        {
            //This avoid lots of comments about WHAT you are doing
            //What it does
            return Convert.ToInt32((intNumber * doubleNumber) / doubleNumber + doubleNumber / intNumber - doubleNumber*intNumber);
        }
    }

    /// <summary>
    /// Generic test class
    /// </summary>
    public class TestClass
    {
        private int randomAttribute;
    }

}