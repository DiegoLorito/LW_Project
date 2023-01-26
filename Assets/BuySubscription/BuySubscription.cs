using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace Samples.Purchasing.Core.BuyingSubscription
{
    public class BuySubscription: MonoBehaviour, IStoreListener
    {
        IStoreController m_StoreController;
        bool show = false;

        // Your subscription ID. It should match the id of your subscription in your store.
        public string monthlySubscriptionId = "com.brightloritos.monthlyplan"; 
        public string annualSubscriptionId = "com.brightloritos.yearlyplan";


        public Text isSubscribedText;

        public GameObject subpanel;
        public GameObject already;


        void Start()
        {
            InitializePurchasing();
            
        }

        void InitializePurchasing()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            // Add our purchasable product and indicate its type.
            builder.AddProduct(monthlySubscriptionId, ProductType.Subscription); 
            builder.AddProduct(annualSubscriptionId, ProductType.Subscription);

            UnityPurchasing.Initialize(this, builder);
        }
        public void BuyMonthlySubscription()
        {
            m_StoreController.InitiatePurchase(monthlySubscriptionId);
            
        }

        public void BuyAnnualSubscription()
        {
            m_StoreController.InitiatePurchase(annualSubscriptionId); 
        }
       

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log("In-App Purchasing successfully initialized");
            m_StoreController = controller;

            UpdateUI();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {

            Debug.Log($"In-App Purchasing initialize failed: {error}");

        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            // Retrieve the purchased product
            var product = args.purchasedProduct;

           Debug.Log($"Purchase Complete - Product: {product.definition.id}");

            gameobject();
            UpdateUI();

            // We return Complete, informing IAP that the processing on our side is done and the transaction can be closed.
            return PurchaseProcessingResult.Complete;

        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
          

        }

        bool IsSubscribedTo(Product subscription)
        {
            // If the product doesn't have a receipt, then it wasn't purchased and the user is therefore not subscribed.
            if (subscription.receipt == null)
            {

                return false;
            }

            //The intro_json parameter is optional and is only used for the App Store to get introductory information.
            var subscriptionManager = new SubscriptionManager(subscription, null);

            // The SubscriptionInfo contains all of the information about the subscription.
            // Find out more: https://docs.unity3d.com/Packages/com.unity.purchasing@3.1/manual/UnityIAPSubscriptionProducts.html
            var info = subscriptionManager.getSubscriptionInfo();

            return info.isSubscribed() == Result.True;
        }

        void UpdateUI()
        {
            //var subscriptionProduct = m_StoreController.products.WithID(subscriptionProductId);
            var monthlySubscriptionProduct = m_StoreController.products.WithID(monthlySubscriptionId); 
            var annualSubscriptionProduct = m_StoreController.products.WithID(annualSubscriptionId);

            try
            {
                var isMonthlySubscribed = IsSubscribedTo(monthlySubscriptionProduct);
                var isAnnualSubscribed = IsSubscribedTo(annualSubscriptionProduct);
                isSubscribedText.text = isMonthlySubscribed ? "You are subscribed" : "You are Subscribed";
                isSubscribedText.text = isAnnualSubscribed ? "You are subscribed" : "You are Subscribed";
            }
            catch (StoreSubscriptionInfoNotSupportedException)
            {
                var monthlyreceipt = (Dictionary<string, object>)MiniJson.JsonDecode(monthlySubscriptionProduct.receipt);
                var annualreceipt = (Dictionary<string, object>)MiniJson.JsonDecode(annualSubscriptionProduct.receipt);
                var monthlystore = monthlyreceipt ["Store"];
                var annualstore = annualreceipt["Store"];
                isSubscribedText.text =
                    "Couldn't retrieve subscription information because your current store is not supported.\n" +
                    $"Your store: \"{monthlystore}{annualstore}\"\n\n" +
                    "You must use the App Store, Google Play Store or Amazon Store to be able to retrieve subscription information.\n\n" +
                    "For more information, see README.md";
            }

        }

        public void CheckMonthlySubscriptionStatus()
        {
            // Get the product information for the subscription
            var monthlyProduct = m_StoreController.products.WithID(monthlySubscriptionId);
            var annualProduct = m_StoreController.products.WithID(annualSubscriptionId);
            Debug.Log("product has receipt" + monthlyProduct.hasReceipt);
            if (monthlyProduct != null && monthlyProduct.hasReceipt || annualProduct != null && annualProduct.hasReceipt)
            {
                // The subscription has been already purchased
               
                Debug.Log("Subscription has been already purchased.");
                subAlready();
            }
            else
            {
                // The subscription has not been already purchased
                Debug.Log("Subscription has not been already purchased.");
                show = true;
                BuyMonthlySubscription();
                
            }

        }
        
        public void CheckAnnualSubscriptionStatus()
        {
            // Get the product information for the subscription
            var monthlyProduct = m_StoreController.products.WithID(monthlySubscriptionId);
            var annualProduct = m_StoreController.products.WithID(annualSubscriptionId);
            Debug.Log("product has receipt" + annualProduct.hasReceipt);
            if (monthlyProduct != null && monthlyProduct.hasReceipt || annualProduct != null && annualProduct.hasReceipt)
            {
                // The subscription has been already purchased
               
                Debug.Log("Subscription has been already purchased.");
                subAlready();
            }
            else
            {
                // The subscription has not been already purchased
                Debug.Log("Subscription has not been already purchased.");
                show = true;
                BuyAnnualSubscription();

            }

        }

        public void subAlready()
        {
            already.SetActive(true);
        }
        public void gameobject()
        {
            subpanel.SetActive(show);
        }

        public void close()
        {
            subpanel.SetActive(false);
            already.SetActive(false);
        }
    }
}
