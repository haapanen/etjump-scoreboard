${
    Template(Settings settings)
    {
        settings
            .IncludeProject("ETJump.Scoreboard.Core")
            ;
        
        settings.OutputExtension = ".ts";
    }

    string TypeConverter(Type type)
    {  
        if(type.Name == "Date")
            return "string";  
        return type.Name;  
    } 
}$Classes(*Criteria)[export interface $Name { $Properties[
    $name: $Type[$TypeConverter];]
}]