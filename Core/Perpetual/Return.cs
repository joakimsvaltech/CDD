﻿namespace CDD.Core.Perpetual
{
    public class Return : Expression
    {
        public Return(Expression statement)
            => Statement = statement;

        public Expression Statement { get; }

        public override bool Accept(Temporal.Expression expression) => false;
    }
}