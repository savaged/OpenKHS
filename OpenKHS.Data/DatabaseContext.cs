using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;
using SQLitePCL;

namespace OpenKHS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<LocalCongregationMember> LocalCongregationMembers { get; set; }
        public DbSet<DateRange> UnavailablePeriods { get; set; }
        public DbSet<PmSchedule> PmSchedules { get; set; }
        public DbSet<ClmmSchedule> ClmmSchedules { get; set; }
        public DbSet<PublicTalk> PublicTalks { get; set; }
        public DbSet<VisitingSpeaker> VisitingSpeakers { get; set; }
        public DbSet<NeighbouringCongregation> NeighbouringCongregations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var databaseFilePath = "OpenKHS.db";
                databaseFilePath = ApplicationData.ResourceLocation + databaseFilePath;
                optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
            }
            Batteries.Init();
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<LocalCongregationMember>()
                .HasIndex(f => f.Name).IsUnique();

            mb.Entity<VisitingSpeaker>()
                .HasIndex(f => f.Name).IsUnique();

            mb.Entity<PmSchedule>()
                .HasIndex(s => s.WeekStarting).IsUnique();

            mb.Entity<ClmmSchedule>()
                .HasIndex(s => s.WeekStarting).IsUnique();

            SeedPublicTalks(mb);
        }

        private void SeedPublicTalks(ModelBuilder mb)
        {
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 1, Name = "How Well Do You Know God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 2, Name = "Will You Be a Survivor of the Last Days?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 3, Name = "Move Ahead With Jehovah’s Uniﬁed Organization" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 4, Name = "Evidence of God in the World Around Us" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 5, Name = "Real Help for the Family" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 6, Name = "The Flood of Noah’s Day and You" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 7, Name = "Imitate “the Father of Tender Mercies”" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 8, Name = "Living to Do God’s Will, Not Our Own" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 9, Name = "Be a Hearer and a Doer of God’s Word" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 10, Name = "Be Honest in All You Say and Do" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 11, Name = "“No Part of the World”—In Imitation of Christ" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 12, Name = "Your View of Authority Matters to God" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 13, Name = "A Godly View of Sex and Marriage" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 14, Name = "A Clean People Honors Jehovah" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 15, Name = "“Work What Is Good Toward All”" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 16, Name = "Keep Growing in Your Relationship With God" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 17, Name = "Glorifying God With All We Have" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 18, Name = "Are You Really Making Jehovah Your Stronghold?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 19, Name = "Your Future—How Can It Be Known?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 20, Name = "Is It Time for God to Rule the World?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 21, Name = "How Do You Fit Into the Kingdom Arrangement?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 22, Name = "Are You Content With Jehovah’s Provisions?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 23, Name = "Life Does Have a Purpose" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 24, Name = "What God’s Rulership Can Do for Us" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 25, Name = "Resisting the Spirit of the World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 26, Name = "Does God Count You Personally Important?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 27, Name = "Getting Marriage Off to a Good Start" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 28, Name = "Show Respect and Love in Your Marriage" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 29, Name = "Responsibilities and Rewards of Parenthood" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 30, Name = "Communication—Within the Family and With God" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 31, Name = "Happy Though Hungry—How Can It Be?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 32, Name = "Coping With Life’s Anxieties" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 33, Name = "What Is Behind the Spirit of Rebellion?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 34, Name = "Are You “Marked” for Survival?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 35, Name = "Can You Live Forever? Will You?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 36, Name = "Is This Life All There Is?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 37, Name = "Are God’s Ways Really Beneﬁcial?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 38, Name = "Act Wisely as the End Draws Near" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 39, Name = "Be Conﬁdent of Divine Victory!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 40, Name = "What the Near Future Holds!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 41, Name = "“Stand Still and See the Salvation of Jehovah”" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 42, Name = "How the Kingdom of God Affects You" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 43, Name = "Are You Doing What God Requires of You?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 44, Name = "Keep Seeking God’s Kingdom" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 45, Name = "Follow the Way to Life" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 46, Name = "Maintain Your Conﬁdence Firm to the End" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 47, Name = "“Have Faith in the Good News”" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 48, Name = "Meeting the Test of Christian Loyalty" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 49, Name = "A Cleansed Earth—Will You Live to See It?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 50, Name = "Decisions You Face—How Will You Make Them?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 51, Name = "Is the Truth Transforming Your Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 52, Name = "Who Is Your God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 53, Name = "Does Your Thinking Agree With God’s?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 54, Name = "Build Your Faith in Man’s Maker" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 55, Name = "What Kind of Name Are You Making With God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 56, Name = "Into the New World Under Christ’s Leadership" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 57, Name = "Bearing Up Under Persecution" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 58, Name = "How Should You Serve God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 59, Name = "You Will Reap What You Sow" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 60, Name = "How Purposeful Is Your Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 61, Name = "On Whose Promises Do You Rely?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 62, Name = "The Only Cure for Sick Mankind" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 63, Name = "Do You Have the Evangelizing Spirit?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 64, Name = "Lovers of Pleasure or Lovers of God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 65, Name = "How to Cultivate Peace in an Angry World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 66, Name = "Slave for the Master of the Harvest" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 67, Name = "Taking Time to Meditate on Spiritual Things" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 68, Name = "Do You Harbor Resentment, or Do You Forgive?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 69, Name = "Renewing the Spirit of Self-Sacriﬁce" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 70, Name = "Make Jehovah Your Conﬁdence" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 71, Name = "How to Keep Spiritually Awake" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 72, Name = "Love Identiﬁes the True Christian Congregation" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 73, Name = "Acquiring a Heart of Wisdom" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 74, Name = "Jehovah’s Eyes Are Upon Us" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 75, Name = "Do You Recognize Jehovah’s Sovereignty in Your Personal Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 76, Name = "Bible Principles—Can They Help Us to Cope With Today’s Problems?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 77, Name = "Follow the Course of Hospitality" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 78, Name = "Serve Jehovah With a Joyful Heart" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 79, Name = "Friendship With God, Friendship With the World—Which Will You Choose?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 80, Name = "Does Your Hope Rest on Science or the Bible?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 81, Name = "Who Are Qualiﬁed as Ministers of God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 82, Name = "Jehovah and Christ—Are They Part of a Trinity?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 83, Name = "Religion’s Time of Judgment" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 84, Name = "Will You Escape This World’s Destiny?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 85, Name = "Good News in a Violent World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 86, Name = "Prayers That Are Heard by God" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 87, Name = "What Is Your Relationship With God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 88, Name = "Why Live by Bible Standards?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 89, Name = "Come, You Who Thirst for the Truth!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 90, Name = "Reach Out for the Real Life!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 91, Name = "The Messiah’s Presence and His Rule" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 92, Name = "Religion’s Role in World Affairs" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 93, Name = "“Acts of God”—How Do You View Them?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 94, Name = "True Religion Meets the Needs of Human Society" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 95, Name = "The Bible’s View of Spiritistic Practices" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 96, Name = "False Religion’s End Is Near" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 97, Name = "Remaining Blameless Amid a Crooked Generation" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 98, Name = "“The Scene of This World Is Changing”" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 99, Name = "Why You Can Trust the Bible" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 100, Name = "True Friendship With God and Neighbor" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 101, Name = "Jehovah—The Grand Creator" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 102, Name = "Paying Attention to the Prophetic Word" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 103, Name = "You Can Find Joy in Serving God" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 104, Name = "Parents—Are You Building With Fire-Resistant Materials?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 105, Name = "Gaining Comfort in All Our Tribulations" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 106, Name = "Ruining the Earth Brings Divine Retribution" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 107, Name = "Hold a Good Conscience in a Sinful World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 108, Name = "Overcoming Fear of the Future" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 109, Name = "The Kingdom of God Is Near" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 110, Name = "God Comes First in Successful Family Life" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 111, Name = "What Does the Healing of the Nations Accomplish?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 112, Name = "How to Express Love in a Lawless World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 113, Name = "How Can Youths Cope With Today’s Crisis?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 114, Name = "Appreciating Marvels of God’s Creation" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 115, Name = "How to Protect Ourselves From Satan’s Snares" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 116, Name = "Choose Your Associates Wisely!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 117, Name = "How to Conquer Evil With Good" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 118, Name = "Looking at Youths From Jehovah’s Standpoint" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 119, Name = "Christian Separateness From the World—Why Beneﬁcial" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 120, Name = "Why Submit to God’s Rulership Now" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 121, Name = "A Worldwide Brotherhood Saved From Calamity" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 122, Name = "Global Peace—From What Source?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 123, Name = "Why Christians Must Be Different" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 124, Name = "Basis for Conﬁdence in the Bible’s Divine Authorship" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 125, Name = "Why Mankind Needs a Ransom" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 126, Name = "Who Can Be Saved?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 127, Name = "What Happens When We Die?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 128, Name = "Is Hell Really a Place of Fiery Torment?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 129, Name = "Is the Trinity a Scriptural Teaching?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 130, Name = "The Earth Will Remain Forever" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 131, Name = "Is There Really a Devil?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 132, Name = "The Resurrection—Victory Over Death!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 133, Name = "The Origin of Humans—Does It Matter What You Believe?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 134, Name = "Should Christians Keep the Sabbath?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 135, Name = "The Sacredness of Life and Blood" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 136, Name = "Does God Approve of the Use of Images in Worship?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 137, Name = "Did the Miracles of the Bible Really Happen?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 138, Name = "Live With Soundness of Mind in a Depraved World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 139, Name = "Godly Wisdom in a Scientiﬁc World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 140, Name = "Jesus Christ—Earth’s New Ruler" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 141, Name = "Human Creation’s Groaning—When Will It End?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 142, Name = "Why Take Refuge in Jehovah" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 143, Name = "Trust in the God of All Comfort" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 144, Name = "A Loyal Congregation Under Christ’s Leadership" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 145, Name = "Who Is Like Jehovah Our God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 146, Name = "Use Education to Praise Jehovah" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 147, Name = "Trust in Jehovah’s Saving Power" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 148, Name = "Do You Share God’s View of Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 149, Name = "Are You Walking With God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 150, Name = "How Real Is God to You?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 151, Name = "Jehovah Is “a Secure Height” for His People" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 152, Name = "The Real Armageddon—Why? When?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 153, Name = "Keep Close in Mind the “Fear-Inspiring Day”!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 154, Name = "Human Rule—Weighed in the Balance" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 155, Name = "Has Babylon’s Judgment Hour Arrived?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 156, Name = "Judgment Day—A Time of Fear or Hope?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 157, Name = "How True Christians Adorn Divine Teaching" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 158, Name = "Be Courageous, and Trust in Jehovah" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 159, Name = "Finding Security in a Dangerous World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 160, Name = "Safeguard Your Christian Identity!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 161, Name = "Why Did Jesus Suffer and Die?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 162, Name = "Deliverance From a World of Darkness" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 163, Name = "Why Fear the True God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 164, Name = "Is God Still in Control?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 165, Name = "Whose Values Do You Cherish?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 166, Name = "Facing the Future With Faith and Courage" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 167, Name = "Act Wisely in a Senseless World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 168, Name = "You Can Feel Safe in This Troubled World!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 169, Name = "Why Be Guided by the Bible?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 170, Name = "Who Is Qualiﬁed to Rule Mankind?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 171, Name = "You Can Enjoy Life in Peace Now—And Forever!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 172, Name = "What Is Your Standing With God?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 173, Name = "Is There a True Religion From God’s Standpoint?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 174, Name = "God’s New World—Who Will Qualify to Enter?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 175, Name = "What Marks the Bible as Authentic?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 176, Name = "Real Peace and Security—When?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 177, Name = "Where Can You Get Help in Times of Distress?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 178, Name = "Walk in the Way of Integrity" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 179, Name = "Reject Worldly Fantasies, Pursue Kingdom Realities" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 180, Name = "The Resurrection—Why That Hope Should Be Real to You" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 181, Name = "Is It Later Than You Think?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 182, Name = "What God’s Kingdom Is Doing for Us Now" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 183, Name = "Turn Your Eyes Away From Worthless Things!" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 184, Name = "Does Death End It All?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 185, Name = "Does the Truth Affect Your Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 186, Name = "Unite With God’s Happy People" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 187, Name = "Why Would a Loving God Permit Wickedness?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 188, Name = "Is Your Conﬁdence in Jehovah?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 189, Name = "Walking With God Brings Blessings Now and Forever" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 190, Name = "A Promise of Perfect Family Happiness" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 191, Name = "How Love and Faith Conquer the World" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 192, Name = "Are You on the Road to Everlasting Life?" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 193, Name = "Rescue From World Distress" });
            mb.Entity<PublicTalk>().HasData(new PublicTalk { Id = 194, Name = "How Godly Wisdom Beneﬁts Us" });
        }
    }
}
