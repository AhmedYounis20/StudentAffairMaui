namespace StudentAffairMaui;

public class Internet
{
    public static bool CheckInternet() => (Connectivity.Current.NetworkAccess == NetworkAccess.Internet);
          
        
    
}
