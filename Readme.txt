1. https://localhost:5001/swagger/index.html

2. AddItems Controller

Use POST /AddItems to create items in system
Use GET /AddItems/ReadItems to read back newly created items
Use GET /AddItems/GetItem to read a single item details

3. Checkout Controller

Use POST /Checkout to scan an item at checkout & keep scanning items to prepare your checkout
Use Read Items to list the items currently in checkout

Use GET /Checkout/ListItemsInCheckout to read items currently in checkout
Use GET /Checkout/RequestTotal to get the total price in checkout now

3. Add Special Offers Controller

Use POST /AddSpecialOffers to create special offers for items using sku
Use GET /AddSpecialOffers to read back the current items offer

4. Again in Checkout controller, use POST /Checkout to add an item again to checkout to see it's effect on the total price

5. Use GET /Checkout/RequestTotal to see the reduction in total price

6. Use GET /Checkout/DiscountApplied to see the item discounts

