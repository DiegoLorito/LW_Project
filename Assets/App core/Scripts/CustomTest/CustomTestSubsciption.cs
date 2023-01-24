using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class CustomTestSubsciption : MonoBehaviour, IStoreListener
{
    IStoreController m_StoreController;
    public string subscriptionProductId = "com.DefaultCompany.app_test";
    public Text txtSubscription;

    private void Start()
    {
        InitializePurchasing();
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add our purchasable product and indicate its type.
        builder.AddProduct(subscriptionProductId, ProductType.Subscription);

        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;

        //UpdateUI();
    }
    void UpdateUI()
    {
        var subscriptionProduct = m_StoreController.products.WithID(subscriptionProductId);

        try
        {
            var isSubscribed = IsSubscribedTo(subscriptionProduct);
            txtSubscription.text = isSubscribed ? "Successfully Completed" : "Not subscribed";
        }
        catch (StoreSubscriptionInfoNotSupportedException)
        {
            var receipt = (Dictionary<string, object>)MiniJson.JsonDecode(subscriptionProduct.receipt);
            var store = receipt["Store"];
            txtSubscription.text =
                "Couldn't retrieve subscription information because your current store is not supported.\n" +
                $"Your store: \"{store}\"\n\n" +
                "You must use the App Store, Google Play Store or Amazon Store to be able to retrieve subscription information.\n\n" +
                "For more information, see README.md";
        }
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
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        txtSubscription.text = "Initialization Failed";
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        // Retrieve the purchased product
        var product = purchaseEvent.purchasedProduct;

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");
        UpdateUI();

        // We return Complete, informing IAP that the processing on our side is done and the transaction can be closed.
        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        throw new NotImplementedException();
    }
    public void BuySubscription()
    {
        m_StoreController.InitiatePurchase(subscriptionProductId);
    }
}
