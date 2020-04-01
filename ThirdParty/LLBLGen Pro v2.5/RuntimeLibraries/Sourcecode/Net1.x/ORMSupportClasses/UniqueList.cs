//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2007 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Simon Hewitt
//		- Frans Bouma
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Provides a faster way to store individual objects both maintaining the order that they were added and
	/// providing a fast lookup.
	/// 
	/// Based on code developed by ewbi at http://ewbi.blogs.com/develops/2006/10/uniquestringlis.html
	/// </summary>
	/// <typeparam name="T">the type of the elements contained in the uniquelist. </typeparam>
	internal class UniqueEntityBase2List: IList
	{
		#region Statics
		private const float LoadFactor = .72f;

		// Based on Golden Primes (as far as possible from nearest two powers of two)
		// at http://planetmath.org/encyclopedia/GoodHashTablePrimes.html
		private static readonly int[] primeNumberList = new int[]
			{
				53, 97, 193, 389, 769, 1543, 3079, 6151, 12289, 24593, 49157, 98317, 196613, 393241, 786433, 1572869, 
				3145739, 6291469, 12582917, 25165843, 50331653, 100663319, 201326611, 402653189, 805306457, 1610612741
			};
		#endregion
		
		#region Class Property Declarations
		private IComparer _comparer;
		private EntityBase2[] _items;
		private int _bucketCapacity, _primeNumberListIndex, _nextItemIndex;
		private int[] _buckets;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public UniqueEntityBase2List(): this(0) 
		{
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="capacity">initial capacity</param>
		public UniqueEntityBase2List(int capacity): this(capacity, null) 
		{
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="comparer">Comparer to use for uniqueness comparison</param>
		public UniqueEntityBase2List(IReferencedEntityComparer comparer): this(0, comparer) 
		{
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="capacity">Initial capacity</param>
		/// <param name="comparer">Comparer to use for uniqueness comparison</param>
		public UniqueEntityBase2List(int capacity, IReferencedEntityComparer comparer)
		{
			if(capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if(comparer == null)
			{
				this._comparer = Comparer.Default;
			}
			else
			{
				this._comparer = comparer;
			}
			Initialize(capacity);
		}
	

		/// <summary>
		/// Determines the index of a specific item in the <see cref="T:System.Collections.IList"></see>.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.IList"></see>.</param>
		/// <returns>
		/// The index of item if found in the list; otherwise, -1.
		/// </returns>
		public int IndexOf(EntityBase2 item)
		{
			return _buckets[GetBucketIndex(item)] - 1;
		}

		/// <summary>
		/// Inserts an item to the <see cref="T:System.Collections.IList"></see> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="item">The object to insert into the <see cref="T:System.Collections.IList"></see>.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>.</exception>
		public void Insert(int index, EntityBase2 item) 
		{ 
			throw new NotImplementedException(); 
		}

		/// <summary>
		/// Removes the <see cref="T:System.Collections.IList"></see> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>.</exception>
		void IList.RemoveAt(int index) 
		{ 
			throw new NotImplementedException(); 
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.ICollection"></see>.</param>
		/// <returns>
		/// true if item was successfully removed from the <see cref="T:System.Collections.ICollection"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.ICollection"></see>.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.ICollection"></see> is read-only.</exception>
		public bool Remove(EntityBase2 item) 
		{
			throw new NotImplementedException(); 
		}


		/// <summary>
		/// Adds the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		public bool Add(EntityBase2 item)
		{
			if(item == null)
			{
				throw new ArgumentNullException("item");
			}

			int index = GetBucketIndex(item);
			if (_buckets[index] == 0)
			{
				_items[_nextItemIndex++] = item;
				_buckets[index] = _nextItemIndex;
				if(_nextItemIndex == _items.Length)
				{
					Expand();
				}
				return true;
			}
			return false;
		}


		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.ICollection"></see> is read-only. </exception>
		public void Clear()
		{
			Initialize(0);
		}


		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.ICollection"></see> contains a specific value.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.ICollection"></see>.</param>
		/// <returns>
		/// true if item is found in the <see cref="T:System.Collections.ICollection"></see>; otherwise, false.
		/// </returns>
		public bool Contains(EntityBase2 item)
		{
			return IndexOf(item) != -1;
		}


		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.ICollection"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
		/// <exception cref="T:System.ArgumentNullException">array is null.</exception>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or-arrayIndex is equal to or greater than the length of array.-or-The number of elements in the source <see cref="T:System.Collections.ICollection"></see> is greater than the available space from arrayIndex to the end of the destination array.-or-Type T cannot be cast automatically to the type of the destination array.</exception>
		public void CopyTo(Array array, int arrayIndex)
		{
			_items.CopyTo(array, arrayIndex);
		}


		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.IEnumerator"></see> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			EntityBase2[] array = new EntityBase2[Count];
			for (int i = 0; i < Count; i++)
			{
				array[i] = _items[i];
			}
			return new ArrayList(array).GetEnumerator();
		}


		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}



		/// <summary>
		/// Initializes the specified min capacity.
		/// </summary>
		/// <param name="minCapacity">The min capacity.</param>
		private void Initialize(int minCapacity)
		{
			int itemCapacity = Math.Max(minCapacity, 38);
			_bucketCapacity = (int)(itemCapacity / LoadFactor);

			_primeNumberListIndex = 0;
			while(primeNumberList[_primeNumberListIndex] < _bucketCapacity)
			{
				_primeNumberListIndex++;
			}

			_bucketCapacity = primeNumberList[_primeNumberListIndex++];
			_items = new EntityBase2[itemCapacity];
			_buckets = new int[_bucketCapacity];
		}


		/// <summary>
		/// Gets the index of the bucket.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		private int GetBucketIndex(EntityBase2 item)
		{
			int hashCode = ((IReferencedEntityComparer)_comparer).GetHashCode(item) & 0x7fffffff;
			int index = hashCode % _bucketCapacity;
			int increment = (index > 1) ? index : 1;
			int i = _bucketCapacity;
			while(0 < i--)
			{
				int itemIndex = _buckets[index];
				if(itemIndex == 0)
				{
					return index;
				}
				if(_comparer.Compare(_items[itemIndex - 1], item) == 0)
				{
					return index;
				}
				index = (index + increment) % _bucketCapacity;
			}
			throw new InvalidOperationException("Failed to locate bucket for item");
		}


		/// <summary>
		/// Expands this instance.
		/// </summary>
		private void Expand()
		{
			_bucketCapacity = primeNumberList[_primeNumberListIndex++];
			int itemCapacity = (int)(_bucketCapacity * LoadFactor);
			_buckets = new int[_bucketCapacity];
			EntityBase2[] newItems = new EntityBase2[itemCapacity];
			_items.CopyTo(newItems, 0);
			_items = newItems;
			ReindexItems();
		}


		/// <summary>
		/// Reindexes the items.
		/// </summary>
		private void ReindexItems()
		{
			for(int i = 0; i < _nextItemIndex; i++)
			{
				_buckets[GetBucketIndex(_items[i])] = i + 1;
			}
		}

		
		#region IList Members

		object System.Collections.IList.this[int index]
		{
			get
			{
				// TODO:  Add UniqueEntityBase2List.System.Collections.IList.this getter implementation
				return null;
			}
			set
			{
				// TODO:  Add UniqueEntityBase2List.System.Collections.IList.this setter implementation
			}
		}

		public void RemoveAt(int index)
		{
			// TODO:  Add UniqueEntityBase2List.RemoveAt implementation
		}

		public void Insert(int index, object value)
		{
			// TODO:  Add UniqueEntityBase2List.Insert implementation
		}

		public void Remove(object value)
		{
			// TODO:  Add UniqueEntityBase2List.Remove implementation
		}

		bool System.Collections.IList.Contains(object value)
		{
			// TODO:  Add UniqueEntityBase2List.System.Collections.IList.Contains implementation
			return false;
		}

		int System.Collections.IList.IndexOf(object value)
		{
			// TODO:  Add UniqueEntityBase2List.System.Collections.IList.IndexOf implementation
			return 0;
		}

		int System.Collections.IList.Add(object value)
		{
			// TODO:  Add UniqueEntityBase2List.System.Collections.IList.Add implementation
			return 0;
		}

		public bool IsFixedSize
		{
			get
			{
				// TODO:  Add UniqueEntityBase2List.IsFixedSize getter implementation
				return false;
			}
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get
			{
				// TODO:  Add UniqueEntityBase2List.IsSynchronized getter implementation
				return false;
			}
		}

		public object SyncRoot
		{
			get
			{
				// TODO:  Add UniqueEntityBase2List.SyncRoot getter implementation
				return null;
			}
		}

		#endregion

		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the instance at the specified index.
		/// </summary>
		public EntityBase2 this[int index]
		{
			get
			{
				if(index < 0 || index > Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return _items[index];
			}
			set { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection"></see>.</returns>
		public int Count
		{
			get { return _nextItemIndex; }
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection"></see> is read-only.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.Generic.ICollection"></see> is read-only; otherwise, false.</returns>
		public bool IsReadOnly
		{
			get { return false; }
		}
		#endregion

	}
}