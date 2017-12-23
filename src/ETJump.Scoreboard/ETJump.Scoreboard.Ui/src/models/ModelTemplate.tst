${
    Template(Settings settings)
    {
        settings
            .IncludeProject("ETJump.Scoreboard.Api");
        
        settings.OutputExtension = ".ts";
    }

    string TypeConverter(Type type)
    {  
        if(type.Name == "Date")
            return "string";  
        return type.Name;  
    } 
}$Classes(*Model)[export interface $Name { $Properties[
    $name: $Type[$TypeConverter];]
}]