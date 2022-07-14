import React from 'react';
import { Link } from '@fluentui/react';

export const Home: React.FunctionComponent = () => {
  return (
    <div>
      <h2>Unofficial API & Power Platform connector for <Link href="https://www.duolingo.com" target={"_blank"}>Duolingo</Link></h2>

      <h4>Authentication</h4>
      <p>Add as query string or in the request header:</p>
      <code>x-api-key: base64Encode([DuolingoUsername]:[DuolingoPassword])</code>
      <p>
        Calculate your API Key <Link href={"/access"}>here</Link>.
      </p>
      <h4>Power BI</h4>
      <p>For example, get all your Duolingo languages:</p>
      <code>
        OData.Feed("https://duolingonator.net/odata/languages", null, [ApiKeyName="x-api-key", Implementation = "2.0"])
      </code>
      <p>Authenticate with Web API and enter your API Key</p>

      <h4>Power Apps</h4>
      <p>Create a custom connector from <Link href={"/swagger/v2/swagger.json"}>this</Link> file. More info <Link href={"https://docs.microsoft.com/en-us/connectors/custom-connectors/define-openapi-definition"} target={"_blank"}>here</Link>.</p>
      <h4>Documentation</h4>
      <ul>
        <li>Swagger: <Link href={"/swagger/index.html"} target={"_blank"}>HTML</Link> | <Link href={"/swagger/v2/swagger.json"} target={"_blank"}>JSON</Link> | <Link href={"/swagger/v2/swagger.yaml"} target={"_blank"}>YAML</Link></li>
        <li>OData: <Link href={"/odata"} target={"_blank"}>https://duolingonator.net/odata</Link> | <Link href={"/odata/$metadata"} target={"_blank"}>Metadata</Link></li>
        <li>Source: <Link href={"https://github.com/achappey/Duolingonator"} target={"_blank"}>GitHub</Link></li>
      </ul>
    </div>
  );
}
