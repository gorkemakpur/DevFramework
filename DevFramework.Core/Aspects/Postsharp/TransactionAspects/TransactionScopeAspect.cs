using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]//aspectlerin serializable olması gerekiyor
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {
            
        }

        public override void OnEntry(MethodExecutionArgs args)//entryde option varsa onu gönder yoksa boş gönder
        {
            args.MethodExecutionTag = new TransactionScope(_option);

        }

        public override void OnSuccess(MethodExecutionArgs args) //metod başarılıysa
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args) //değilse
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }


    }
}
