using NativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using static NativeWifi.WlanClient;

namespace Cocu.Services
{
    class WifiScannerService
    {
        // Méthode pour récupérer les informations sur les réseaux Wi-Fi disponibles
        public List<string> GetWifiInformation()
        {
            List<string> wifiInformation = new List<string>();

            // Récupérer les interfaces réseau
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Filtrer uniquement les interfaces connectées et de type Wireless80211
            var connectedWifiInterfaces = networkInterfaces.Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211);

            foreach (var wifiInterface in connectedWifiInterfaces)
            {
                // Obtenir le SSID (nom) du réseau Wi-Fi
                string ssid = wifiInterface.Name;
                string name = wifiInterface.Description;

                // Obtenir l'adresse MAC de l'interface Wi-Fi
                string macAddress = wifiInterface.GetPhysicalAddress().ToString();

                // Ajouter les informations à la liste
                wifiInformation.Add($"SSID: {ssid}, Adresse MAC: {macAddress}, Nom: {name}");
            }

            return wifiInformation;
        }

        // Méthode pour récupérer le nom du réseau Wi-Fi auquel l'appareil est actuellement connecté
        public string GetCurrentWifiName()
        {
            string wifiName = "";

            try
            {
                WlanClient client = new WlanClient();

                // Obtenir le SSID du réseau connecté
                foreach (WlanClient.WlanInterface wlanInterface in client.Interfaces)
                {
                    Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    string ssidName = new string(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength));

                    if (!string.IsNullOrEmpty(ssidName))
                    {
                        wifiName = ssidName;
                        break;  // Sortir de la boucle après avoir trouvé le SSID connecté
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception, la journaliser ou l'ignorer simplement en fonction des besoins de votre application
                Console.WriteLine("Erreur lors de la récupération du SSID Wi-Fi actuel : " + ex.Message);
            }

            return wifiName;
        }

        // Méthode pour récupérer les appareils connectés au même réseau Wi-Fi que l'appareil
        public List<string> GetConnectedDevicesOnWifi()
        {
            List<string> connectedDevices = new List<string>();

            try
            {
                WlanClient client = new WlanClient();
                foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
                {
                    Wlan.Dot11Ssid ssid = wlanIface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    string currentSsid = new string(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength));

                    if (!string.IsNullOrEmpty(currentSsid))
                    {
                        // Obtenir la liste des clients connectés
                        var connectedClients = wlanIface.GetNetworkBssList()
                            .SelectMany(bss => bss.dot11Bssid)
                            .Distinct();

                        foreach (var clientMac in connectedClients)
                        {
                            connectedDevices.Add(clientMac.ToString());
                            MessageBox.Show(clientMac.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception, la journaliser ou l'ignorer simplement en fonction des besoins de votre application
                Console.WriteLine("Erreur lors de l'analyse des appareils connectés : " + ex.Message);
            }

            return connectedDevices;
        }
    }
}
