using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;
using Toha.QIiik.Web.Models;

namespace Toha.QIiik.Web.Services
{
    public class TriangleService : ITriangleService
    {
        public string CheckTypeTriangle(TrianglePostParam value)
        {
            bool bIsMatchFirstTriangle = false;
            bool bIsMatchSecondTriangle = false;
            
            //Check First Triangle
            if (value?.LengthSide1 == value?.LengthSide2) {
                bIsMatchFirstTriangle = true;
            }

            if (value?.LengthSide1 == value?.LengthSide3) {
                bIsMatchFirstTriangle = true;
            }

            if (value?.LengthSide2 == value?.LengthSide3) {
                bIsMatchSecondTriangle = true;
            }

            if (bIsMatchFirstTriangle && bIsMatchSecondTriangle)
                return "Equilateral Triangle: A triangle is considered to be an equilateral triangle when all three sides have the same length.";
            else if (bIsMatchFirstTriangle || bIsMatchSecondTriangle)
                return "Isosceles triangle: When two sides of a triangle are equal or congruent, then it is called an isosceles triangle.";
            else
                return "Scalene triangle: When none of the sides of a triangle are equal, it is called a scalene triangle.";
        }
    }
}
