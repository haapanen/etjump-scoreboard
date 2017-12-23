${
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        settings
            .IncludeProject("ETJump.Scoreboard.Api")
            ;
        
        settings.OutputFilenameFactory = file => {
            return file.Name.Substring(0, file.Name.Length - "controller".Length - 3) + "Api";
        };
        settings.OutputExtension = ".ts";
    }

    string TypeConverter(Type type)
    {  
        if(type.Name == "Date")
            return "string";  
        return type.Name;  
    } 

    string GetControllerName(string name) 
    {
        return name.Substring(0, name.Length - "controller".Length);
    }

    string GetType(Type type) 
    {
        if (type.IsEnumerable) {
            return type.Name.TrimEnd('[', ']');
        }
        return type.Name;
    }

    static List<string> importedTypes = new List<string>();

    string GetImportString(Type type) 
    {
        if (type.IsPrimitive) 
        {
            return "";
        }

        if (importedTypes.Contains(type.Name)) {
            return "";
        } else {
            importedTypes.Add(type.Name);
        }

        return string.Format("import { {0} } from \"../models/{0}\";", type.Name);
    }

    string Imports(Class c) 
    {
        var types = c.Methods.SelectMany(m => new List<Type>{m.Type}.Concat(m.Parameters.Select(p => p.Type)));

        var criterias = types.Where(t => t.Name.EndsWith("Criteria")).Select(type => $"import {{ {GetType(type)} }} from '../criteria/{GetType(type)}'").Distinct();
        var models = types.Where(t => t.Name.EndsWith("Model")).Select(type => $"import {{ {GetType(type)} }} from '../models/{GetType(type)}'").Distinct();

        return string.Join(Environment.NewLine, criterias.Concat(models));
    }

    string GetBody(string requestData) 
    {
        if (requestData == "null") 
        {
            return "";
        }
        return "body: JSON.stringify(" + requestData + ")";
    }
}$Classes(:Controller)[$Imports]
$Classes(:Controller)[import { BaseApi } from "./BaseApi";

export class $Name[$GetControllerName]Api extends BaseApi {
    constructor(baseUrl: string) {
        super(baseUrl);
    } $Methods[
        
    $name = ($Parameters[$name: $Type][, ]): Promise<$Type> => {
        return this.fetch(`$Url`, "$HttpMethod", $RequestData);
    }]
}]