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
using System.IO;
using System.Linq;
using System.Text;

namespace Pytocs.Core.Syntax
{
    public class DottedName : Exp
    {
        public List<Identifier> segs;

        public DottedName(List<Identifier> segs, string filename, int start, int end) : base(filename, start, end)
        {
            this.segs = segs;
        }

        public override void Write(TextWriter writer)
        {
            writer.Write(string.Join(".", segs.Select(s => s.Name)));
        }

        public override T Accept<T>(IExpVisitor<T> v)
        {
            return v.VisitDottedName(this);
        }

        public override void Accept(IExpVisitor v)
        {
            v.VisitDottedName(this);
        }
    }
}
