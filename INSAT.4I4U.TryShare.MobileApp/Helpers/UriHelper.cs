﻿namespace INSAT._4I4U.TryShare.MobileApp.Helpers;

public static class UriHelper
{
    public static Uri CombineUri(params string[] uriParts)
    {
        string uri = string.Empty;
        if (uriParts != null && uriParts.Length > 0)
        {
            char[] trims = new char[] { '\\', '/' };
            uri = (uriParts[0] ?? string.Empty).TrimEnd(trims);
            for (int i = 1; i < uriParts.Length; i++)
            {
                uri = string.Format("{0}/{1}", uri.TrimEnd(trims), (uriParts[i] ?? string.Empty).TrimStart(trims));
            }
        }
        
        return new Uri(uri);
    }
}