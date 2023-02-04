using System;
using System.Collections.Generic;
using System.Text;
using AbpAssignment.Localization;
using Volo.Abp.Application.Services;

namespace AbpAssignment;

/* Inherit your application services from this class.
 */
public abstract class AbpAssignmentAppService : ApplicationService
{
    protected AbpAssignmentAppService()
    {
        LocalizationResource = typeof(AbpAssignmentResource);
    }
}
