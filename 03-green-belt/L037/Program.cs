using FacadePattern.Callers;
using FacadePattern.Legacy;
using FacadePattern.Publishing;
using FacadePattern.Reporting;

// Composition root only. Each pass builds fresh subsystems with a journal,
// so the steps each caller actually ran can be printed.

Pass1ByHand();
Pass2ThroughTheFacade();
Pass3StillReachable();
Pass4Refused();

static void Pass1ByHand()
{
    var buttonSteps = new List<string>();
    new PublishButtonHandler(Subsystems.Build(buttonSteps))
        .OnPublish(Drafts.Clean());

    var jobSteps = new List<string>();
    new ScheduledPublisherByHand(Subsystems.Build(jobSteps))
        .Run(Drafts.Clean());

    Log.Pass("Pass 1: two callers, each doing the steps by hand");
    Log.Item("publish button   " + Describe.Steps(buttonSteps));
    Log.Item("scheduled job    " + Describe.Steps(jobSteps));
}

static void Pass2ThroughTheFacade()
{
    var buttonSteps = new List<string>();
    new PublishButton(new ArticlePublisher(Subsystems.Build(buttonSteps)))
        .OnPublish(Drafts.Clean());

    var jobSteps = new List<string>();
    new ScheduledPublisher(new ArticlePublisher(Subsystems.Build(jobSteps)))
        .Run(Drafts.Clean());

    Log.Pass("Pass 2: both callers through ArticlePublisher");
    Log.Item("publish button   " + Describe.Steps(buttonSteps));
    Log.Item("scheduled job    " + Describe.Steps(jobSteps));
}

static void Pass3StillReachable()
{
    var steps = new List<string>();
    var index = new SearchIndex(steps);

    int count = new ReindexTool(index)
        .ReindexAll(new[] { "facades", "adapters", "decorators" });

    Log.Pass("Pass 3: the admin tool still reaches the index directly");
    Log.Item("reindexed        " + count + " articles");
}

static void Pass4Refused()
{
    var steps = new List<string>();
    var publisher = new ArticlePublisher(Subsystems.Build(steps));

    PublishResult result = publisher.Publish(Drafts.WithTypos());

    Log.Pass("Pass 4: a draft that fails proofreading");
    Log.Item("result           " + result.Summary);
    Log.Item("steps run        " + Describe.Steps(steps));
}
