using System.ComponentModel;

public class Config : Exiled.API.Interfaces.IConfig
{
    [Description("هل تريد تفعيل البلجن؟")]
    public bool IsEnabled { get; set; } = true;

    [Description("تفعيل استخراج السكيمات المضغوطة تلقائياً؟")]
    public bool AutoExtractSchematics { get; set; } = true;

    [Description("تفعيل مراقبة ملفات الخرائط تلقائياً عند التعديل؟")]
    public bool EnableFileWatcher { get; set; } = true;

    [Description("تفعيل نظام تتبع الأداء؟")]
    public bool EnableTracking { get; set; } = false;

    [Description("هل تريد إظهار رسائل الديباغ في الكونسل؟")]
    public bool Debug { get; set; } = false;
    public string MapsDirectory { get; set; } = "./DZCPMaps/";

}