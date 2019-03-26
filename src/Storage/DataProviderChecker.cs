﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SenseNet.ContentRepository.Storage.Schema;

// ReSharper disable once CheckNamespace
namespace SenseNet.ContentRepository.Storage
{
    //UNDONE:DB -------Delete DataProviderChecker feature
    public class DataProviderChecker
    {
        public bool Enabled { get; set; }

        public void Assert_AreEqual(NodeToken[] expected, NodeToken[] actual)
        {
            if (!Enabled)
                return;

            if (expected.Length != actual.Length)
                throw new Exception(
                    $"NodeToken array lengths are not equal. Expected: {expected.Length}, Actual: {actual.Length}");

            expected = expected.OrderBy(x => x.NodeId).ThenBy(x => x.VersionId).ToArray();
            actual = actual.OrderBy(x => x.NodeId).ThenBy(x => x.VersionId).ToArray();
            for (var i = 0; i < expected.Length; i++)
            {
                var exp = expected[i];
                var act = actual[i];

                Assert_AreEqual(exp.NodeId, act.NodeId, i, "NodeId");
                Assert_AreEqual(exp.VersionId, act.VersionId, i, "VersionId");
                Assert_AreEqual(exp.NodeTypeId, act.NodeTypeId, i, "NodeTypeId");
                Assert_AreEqual(exp.ContentListTypeId, act.ContentListTypeId, i, "ContentListTypeId");
                Assert_AreEqual(exp.ContentListId, act.ContentListId, i, "ContentListId");

                Assert_AreEqual(exp.PropertyTypes, act.PropertyTypes, i, "PropertyTypes");
                Assert_AreEqual(exp.ContentListPropertyTypes, act.ContentListPropertyTypes, i,
                    "ContentListPropertyTypes");
                Assert_AreEqual(exp.AllPropertyTypes, act.AllPropertyTypes, i, "AllPropertyTypes");

                Assert_AreEqual(exp.VersionNumber, act.VersionNumber, i, "VersionNumber");
                Assert_AreEqual(exp.NodeHead, act.NodeHead, i);
                Assert_AreEqual(exp.NodeData, act.NodeData, i);
            }

        }

        public void Assert_AreEqual(NodeData expected, NodeData actual)
        {
            Assert_AreEqual(expected.IsShared, actual.IsShared, "IsShared");
            //Assert_AreSame(expected.SharedData, actual.SharedData, "SharedData");
            //
            Assert_AreEqual(expected.Id, actual.Id, -1, "Id");
            Assert_AreEqual(expected.NodeTypeId, actual.NodeTypeId, -1, "NodeTypeId");
            Assert_AreEqual(expected.ContentListId, actual.ContentListId, -1, "ContentListId");
            Assert_AreEqual(expected.ContentListTypeId, actual.ContentListTypeId, -1, "ContentListTypeId");
            Assert_AreEqual(expected.ParentId, actual.ParentId, -1, "ParentId");
            Assert_AreEqual(expected.Name, actual.Name, "Name");
            Assert_AreEqual(expected.DisplayName, actual.DisplayName, "DisplayName");
            Assert_AreEqual(expected.Path, actual.Path, "Path");
            Assert_AreEqual(expected.Index, actual.Index, -1, "Index");
            Assert_AreEqual(expected.CreatingInProgress, actual.CreatingInProgress, "CreatingInProgress");
            Assert_AreEqual(expected.IsDeleted, actual.IsDeleted, "IsDeleted");
            Assert_AreEqual(expected.CreationDate, actual.CreationDate, "CreationDate");
            Assert_AreEqual(expected.ModificationDate, actual.ModificationDate, "ModificationDate");
            Assert_AreEqual(expected.CreatedById, actual.CreatedById, -1, "CreatedById");
            Assert_AreEqual(expected.ModifiedById, actual.ModifiedById, -1, "ModifiedById");
            Assert_AreEqual(expected.VersionId, actual.VersionId, -1, "VersionId");
            Assert_AreEqual(expected.Version, actual.Version, -1, "Version");
            Assert_AreEqual(expected.VersionCreationDate, actual.VersionCreationDate, "VersionCreationDate");
            Assert_AreEqual(expected.VersionModificationDate, actual.VersionModificationDate, "VersionModificationDate");
            Assert_AreEqual(expected.VersionCreatedById, actual.VersionCreatedById, -1, "VersionCreatedById");
            Assert_AreEqual(expected.VersionModifiedById, actual.VersionModifiedById, -1, "VersionModifiedById");
            Assert_AreEqual(expected.Locked, actual.Locked, "Locked");
            Assert_AreEqual(expected.LockedById, actual.LockedById, -1, "LockedById");
            Assert_AreEqual(expected.ETag, actual.ETag, "ETag");
            Assert_AreEqual(expected.LockType, actual.LockType, -1, "LockType");
            Assert_AreEqual(expected.LockTimeout, actual.LockTimeout, -1, "LockTimeout");
            Assert_AreEqual(expected.LockDate, actual.LockDate, "LockDate");
            Assert_AreEqual(expected.LockToken, actual.LockToken, "LockToken");
            Assert_AreEqual(expected.LastLockUpdate, actual.LastLockUpdate, "LastLockUpdate");
            Assert_AreEqual(expected.IsSystem, actual.IsSystem, "IsSystem");
            Assert_AreEqual(expected.OwnerId, actual.OwnerId, -1, "OwnerId");
            Assert_AreEqual(expected.SavingState.ToString(), actual.SavingState.ToString(), "SavingState");
            //Assert_AreEqual_Timestamp(expected, actual, true);
            //Assert_AreEqual_Timestamp(expected, actual, false);
            //
            Assert_AreEqual(expected.ModificationDateChanged, actual.ModificationDateChanged, "ModificationDateChanged");
            Assert_AreEqual(expected.ModifiedByIdChanged, actual.ModifiedByIdChanged, "ModifiedByIdChanged");
            Assert_AreEqual(expected.VersionModificationDateChanged, actual.VersionModificationDateChanged, "VersionModificationDateChanged");
            Assert_AreEqual(expected.VersionModifiedByIdChanged, actual.VersionModifiedByIdChanged, "VersionModifiedByIdChanged");
            Assert_AreEqual(expected.DefaultName, actual.DefaultName, "DefaultName");
            //
            Assert_AreEqual(expected.ChangedData, actual.ChangedData);
        }

        private void Assert_AreSame(object expected, object actual, string name)
        {
            if (!object.ReferenceEquals(expected, actual))
                throw new Exception(
                    $"Expected and actual {name} are not the same equal.");
        }

        private void Assert_AreEqual(IEnumerable<ChangedData> expected, IEnumerable<ChangedData> actual)
        {
            if (expected == null && actual == null)
                return;
            throw new NotImplementedException();
        }

        private void Assert_AreEqual(DateTime expected, DateTime actual, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }

        private void Assert_AreEqual(long expected, long actual, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }

        private void Assert_AreEqual(string expected, string actual, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }

        internal void Assert_AreEqual(NodeSaveSettings expected, NodeSaveSettings actual)
        {
            Assert_AreEqual(expected.Node.Id, actual.Node.Id, -1, "Id");
            Assert_AreEqual(expected.CurrentVersionId, actual.CurrentVersionId, -1, "CurrentVersionId");
            Assert_AreEqual(expected.CurrentVersion, actual.CurrentVersion, -1, "CurrentVersion");
            Assert_AreEqual(expected.ExpectedVersion, actual.ExpectedVersion, -1, "ExpectedVersion");
            Assert_AreEqual(expected.ExpectedVersionId, actual.ExpectedVersionId, -1, "ExpectedVersionId");

            Assert_AreEqual(expected.LastMajorVersionIdBefore, actual.LastMajorVersionIdBefore, -1, "LastMajorVersionIdBefore");
            Assert_AreEqual(expected.LastMinorVersionIdBefore, actual.LastMinorVersionIdBefore, -1, "LastMinorVersionIdBefore");
            Assert_AreEqual(expected.LastMajorVersionIdAfter, actual.LastMajorVersionIdAfter, -1, "LastMajorVersionIdAfter ");
            Assert_AreEqual(expected.LastMinorVersionIdAfter, actual.LastMinorVersionIdAfter, -1, "LastMinorVersionIdAfter ");

            Assert_AreEqual(expected.LockerUserId, actual.LockerUserId, "LockerUserId");
            Assert_AreEqual(expected.VersioningMode, actual.VersioningMode, "VersioningMode");
            Assert_AreEqual(expected.HasApproving, actual.HasApproving, "HasApproving");
            Assert_AreEqual(expected.ForceRefresh, actual.ForceRefresh, "ForceRefresh");
            Assert_AreEqual(expected.TakingLockOver, actual.TakingLockOver, "TakingLockOver");
            Assert_AreEqual(expected.MultistepSaving, actual.MultistepSaving, "MultistepSaving");
            Assert_AreEqual(expected.NeedToSaveData, actual.NeedToSaveData, "NeedToSaveData");

            Assert_AreEqual(expected.DeletableVersionIds, actual.DeletableVersionIds, "DeletableVersionIds");
        }

        private void Assert_AreEqual(List<int> expected, List<int> actual, string name)
        {
            var exp = string.Join(",", expected.OrderBy(x => x).Select(x => x.ToString()));
            var act = string.Join(",", actual.OrderBy(x => x).Select(x => x.ToString()));
            if (exp != act)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {exp}, Actual: {act}");
        }
        private void Assert_AreEqual(bool expected, bool actual, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }
        private void Assert_AreEqual(VersioningMode expected, VersioningMode actual, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }
        private void Assert_AreEqual(int? expected, int? actual, string name)
        {
            if (expected == null && actual == null)
                return;
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Expected: {expected}, Actual: {actual}");
        }

        /* =========================================================================================== Private */

        private void Assert_AreEqual(int expected, int actual, int index, string name)
        {
            if (expected != actual)
                throw new Exception(
                    $"Expected and actual {name} are not equal. Index: {index}. Expected: {expected}, Actual: {actual}");
        }

        private void Assert_AreEqual(VersionNumber expected, VersionNumber actual, int index, string name)
        {
            if (expected.ToString() != actual.ToString())
                throw new Exception(
                    $"Expected and actual VersionNumber are not equal. Index: {index}. Expected: {expected}, Actual: {actual}");
        }

        private void Assert_AreEqual(TypeCollection<PropertyType> expected, TypeCollection<PropertyType> actual,
            int index, string name)
        {
            if (expected.Count != actual.Count)
                throw new Exception(
                    $"Expected and actual {name} count are not equal. Index: {index}. Expected: {expected.Count}, Actual: {actual.Count}");
        }

        private void Assert_AreEqual(NodeHead expected, NodeHead actual, int index)
        {
            throw new NotImplementedException();
        }

        private void Assert_AreEqual(NodeData expected, NodeData actual, int index)
        {
            throw new NotImplementedException();
        }

        /* =========================================================================================== Private */

        public NodeData Clone(NodeData original)
        {
            return original.Clone();
        }

        internal NodeSaveSettings Clone(NodeSaveSettings original)
        {
            return new NodeSaveSettings
            {
                Node = original.Node,
                HasApproving = original.HasApproving,
                VersioningMode = original.VersioningMode,
                ExpectedVersion = original.ExpectedVersion,
                ExpectedVersionId = original.ExpectedVersionId,
                LockerUserId = original.LockerUserId,
                NeedToSaveData = original.NeedToSaveData,
                LastMajorVersionIdBefore = original.LastMajorVersionIdBefore,
                LastMinorVersionIdBefore = original.LastMinorVersionIdBefore,
                LastMajorVersionIdAfter = original.LastMajorVersionIdAfter,
                LastMinorVersionIdAfter = original.LastMinorVersionIdAfter,
                TakingLockOver = original.TakingLockOver,
                MultistepSaving = original.MultistepSaving,
                DeletableVersionIds = original.DeletableVersionIds.ToList(),
            };
        }

    }
}