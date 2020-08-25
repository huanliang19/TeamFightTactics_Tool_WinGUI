using System;

namespace TeamfightTacticsUI_CS_WPF
{
	public class ItemChart
	{
		private static int MAX_ITEM_COUNT = 9;
		private static int MAX_FULL_ITEM_COUNT = 45;
		private static int itemTotal = 0;
		private static int[] itemCount = new int[9];
		private static int[] fullitemCount = new int[45];
		void UpdateChart()
		{
			//Factor in presence of an item by row
			int rowInx = 0;
			for (int i = 0; i < MAX_ITEM_COUNT; i++)
			{
				int cloneInx = 0;
				for (int j = rowInx; j <= rowInx + i; j++)
				{
					fullitemCount[j] = Math.Min(itemCount[i], itemCount[cloneInx]);
					cloneInx++;
				}
				rowInx += i + 1;
			}

			//Divide Diagonals
			int skipInx = 0;
			for (int i = 0; i < MAX_ITEM_COUNT; i++)
			{
				fullitemCount[skipInx] = fullitemCount[skipInx] / 2;
				skipInx += i + 2;
			}
		}

		public int[] GetItems()
		{
			int[] retArr = new int[MAX_FULL_ITEM_COUNT];
			for (int i = 0; i < MAX_FULL_ITEM_COUNT; i++)
			{
				retArr[i] = fullitemCount[i];
			}
			return retArr;
		}

		public void AddItem(int itemIndex)
		{
			itemCount[itemIndex]++;
			itemTotal++;
			UpdateChart();
		}

		public void RemoveFullItem(int itemIndex)
		{
			int x = 0;
			int y = itemIndex;
			while (y > x)
			{
				x++;
				y -= x;
			}
			RemoveItem(y);
			RemoveItem(x);
			UpdateChart();
		}

		private void RemoveItem(int itemIndex)
		{
			if (itemCount[itemIndex] > 0)
			{
				itemCount[itemIndex]--;
				itemTotal--;
			}
		}

		public void Reset()
		{
			for(int i = 0; i < MAX_ITEM_COUNT-1; i++)
			{
				itemCount[i] = 0;
			}

			for (int i = 0; i < MAX_FULL_ITEM_COUNT - 1; i++)
			{
				fullitemCount[i] = 0;
			}

			itemTotal = 0;
			UpdateChart();
		}
	}
}
