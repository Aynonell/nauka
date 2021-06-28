using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public static readonly OperationResult Success 
            = new OperationResult()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "OK"
            };

        public static readonly OperationResult Error
            = new OperationResult()
            {
                IsSuccess = false,
                ErrorCode = 0,
                Message = "Coś poszło nie tak"
            };


        public static readonly OperationResult ErrorInputData
            = new OperationResult()
            {
                IsSuccess = false,
                ErrorCode = 4,
                Message = "Niewłaściwe dane wejściowe"
            };
    }
}
