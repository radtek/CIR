using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir {
	public class CirComment {

		public enum Type {
			General = 0,
			Approve = 1,
			Reject = 2,
			MoveToInitial = 3,
			Deleted = 4
		}

		private readonly long _commentId;
		private readonly long _cirDataId;
		private readonly DateTime _date;
		private readonly string _initials;
		private readonly string _comment;
		private readonly Type _type;

		public CirComment(long commentId, long cirDataId, DateTime date, string initials, string comment, Type type) {
			_commentId = commentId;
			_cirDataId = cirDataId;
			_date = date;
			_initials = initials;
			_comment = comment;
			_type = type;
		}

		public Type CommentType {
			get { return _type; }
		}

		public long CommentId {
			get { return _commentId; }
		}

		public long CirDataId {
			get { return _cirDataId; }
		}

		public DateTime Date {
			get { return _date; }
		}

		public string Initials {
			get { return _initials; }
		}

		public string Comment {
			get { return _comment; }
		}
	}
}
