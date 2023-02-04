using AbpAssignment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpAssignment.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpAssignmentController : AbpControllerBase
{
    protected AbpAssignmentController()
    {
        LocalizationResource = typeof(AbpAssignmentResource);
    }
}
