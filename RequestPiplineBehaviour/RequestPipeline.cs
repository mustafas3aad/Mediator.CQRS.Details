using FluentValidation;
using MediatR;

namespace Mediator.CQRS.RequestPiplineBehaviour   
{
    // Note:
    // This is ( Pre )
    public class RequestPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            //Note:
            // pre => Validation
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(v => v.Validate(context)).SelectMany(r => r.Errors).Where(f => f != null).ToList();

            //Note:
            // if validation is failed, it will not execute the next handler and throw an exception instead and go to ( post ).
            if ( failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();



        }
    }
}
