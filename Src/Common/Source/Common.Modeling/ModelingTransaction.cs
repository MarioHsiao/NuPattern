﻿using Microsoft.VisualStudio.Modeling;

namespace NuPattern.Modeling
{
    /// <summary>
    /// Default implementation of a transaction that wraps the DSL transaction.
    /// </summary>
    public sealed class ModelingTransaction : ITransaction
    {
        private Transaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelingTransaction"/> class.
        /// </summary>
        public ModelingTransaction(Transaction transaction)
        {
            this.transaction = transaction;
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public void Commit()
        {
            this.transaction.Commit();
        }

        /// <summary>
        /// Aborts the transaction.
        /// </summary>
        public void Rollback()
        {
            this.transaction.Rollback();
        }

        /// <summary>
        /// Disposes the transaction.
        /// </summary>
        public void Dispose()
        {
            this.transaction.Dispose();
        }
    }
}
