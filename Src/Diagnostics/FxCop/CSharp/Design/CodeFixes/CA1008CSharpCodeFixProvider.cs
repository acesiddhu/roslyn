﻿// Copyright (c) Microsoft Open Technologies, Inc.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Composition;
using System.Linq;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FxCopAnalyzers.Design;

namespace Microsoft.CodeAnalysis.CSharp.FxCopAnalyzers.Design
{
    /// <summary>
    /// CA1008: Enums should have zero value
    /// </summary>
    [ExportCodeFixProvider("CA1008", LanguageNames.CSharp), Shared]
    public class CA1008CSharpCodeFixProvider : CA1008CodeFixProviderBase
    {
        internal override SyntaxNode GetFieldInitializer(IFieldSymbol field)
        {
            if (field.DeclaringSyntaxReferences.Length == 0)
            {
                return null;
            }

            var syntax = field.DeclaringSyntaxReferences.First().GetSyntax();
            var enumMemberSyntax = syntax as EnumMemberDeclarationSyntax;
            return enumMemberSyntax == null ? null : enumMemberSyntax.EqualsValue;
        }

        internal override SyntaxNode CreateConstantValueInitializer(SyntaxNode constantValueExpression)
        {
            return SyntaxFactory.EqualsValueClause((ExpressionSyntax)constantValueExpression);
        }
    }
}