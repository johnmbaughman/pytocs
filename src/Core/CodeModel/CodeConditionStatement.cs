#region License
//  Copyright 2015-2021 John Källén
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pytocs.Core.CodeModel
{
    public class CodeConditionStatement : CodeStatement
    {
        public CodeConditionStatement()
        {
            TrueStatements = new List<CodeStatement>();
            FalseStatements = new List<CodeStatement>();
        }

        public CodeExpression? Condition { get; set; }
        public List<CodeStatement> TrueStatements { get; private set; }
        public List<CodeStatement> FalseStatements { get; private set; }

        public override T Accept<T>(ICodeStatementVisitor<T> visitor)
        {
            return visitor.VisitIf(this);
        }
    }
}
