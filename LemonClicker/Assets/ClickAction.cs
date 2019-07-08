using System;
using System.Collections.Generic;

/** Class handling click handling logic */
public class ClickAction
{
    /** Store of all active clicks */
    private List<DateTime> clicks;

    /** Limit of clicks to be stored */
    private int limit;

    /** In seconds when to remove click from list */
    private int cooldown;

    /**
     * Constructor.
     * 
     * @param cooldown in seconds to remove click from list
     * @param limit how many clicks to be stored
     */
    public ClickAction(int cooldown, int limit)
    {
        this.clicks = new List<DateTime>();
        this.cooldown = cooldown;
        this.limit = limit;
    }

    /** @returns the number of clicks stored */
    public int getClicks()
    {
        purgeCooldown();
        return this.clicks.Count;
    }

    /** 
     * @returns the number of clicks within a second.
     */
    public int getClicksPerSecond()
    {
        return this.getCountOfSeconds(1);
    }

    /**
     * Adds clicks to the list.
     * 
     * @param datetime the {@link DateTime} of the click action
     */
    public void onClick(DateTime datetime)
    {
        if (this.clicks.Count < this.limit)
        {
            this.clicks.Add(datetime);
        }
    }

    /**
     * Gets the number of clicks in the provided seconds.
     * 
     * @param seconds the numbers of seconds to filter by
     * @returns the number of clicks in the provided seconds
     */
    private int getCountOfSeconds(int seconds)
    {
        int count = 0;
        this.clicks.ForEach(click =>
        {
            TimeSpan span = DateTime.Now - click;
            if (span.Seconds < seconds)
            {
                count++;
            }
        });
        return count;
    }

    /** 
     * Purges out all clicks in the list that are outwith the cooldown period.
     */
    private void purgeCooldown()
    {
        for (int i = this.clicks.Count - 1; i >= 0; i--)
        {
            TimeSpan span = DateTime.Now - this.clicks[i];
            if (span.Seconds > this.cooldown)
            {
                this.clicks.RemoveAt(i);
            }
        }
    }
}