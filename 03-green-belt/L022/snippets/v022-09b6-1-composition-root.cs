        IInvoiceNumbers shared = new CountingInvoiceNumbers();
        BillingService one = new BillingService(shared);
        BillingService two = new BillingService(shared);
        Log.Line("  two services sharing one source:");
        Log.Line("    " + one.Issue("Acme Tools"));
        Log.Line("    " + two.Issue("Bruno Cafe"));

        BillingService three = new BillingService(new CountingInvoiceNumbers());
        BillingService four = new BillingService(new CountingInvoiceNumbers());
        Log.Line("  two services with one source each:");
        Log.Line("    " + three.Issue("Cascade Ltd"));
        Log.Line("    " + four.Issue("Delta Foods"));
